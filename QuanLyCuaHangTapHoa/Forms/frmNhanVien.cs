using BCrypt.Net;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTapHoa.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmNhanVien : Form
    {
        private readonly QLTHDbContext _context;   // Một instance cho toàn form
        private bool _isAdding = false;
        private int _currentId;
        public frmNhanVien()
        {
            InitializeComponent();
            _context = new QLTHDbContext();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;

            txtMaNhanVien.Enabled = false;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtTenDangNhap.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            cboQuyenHan.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
            txtTimKiem.Enabled = !giaTri;

        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadData();

        }

        private void LoadData()
        {
            var danhSach = _context.NhanVien
                .AsNoTracking()
                .ToList();

            HienThiLenLuoi(danhSach);
        }

        private void HienThiLenLuoi(List<NhanVien> danhSach)
        {
            var bindingSource = new BindingSource { DataSource = danhSach };

            // Clear tất cả binding trước để tránh lỗi
            ClearAllBindings();

            txtMaNhanVien.DataBindings.Add("Text", bindingSource, "MaNhanVien", false, DataSourceUpdateMode.Never);
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);
            txtTenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", false, DataSourceUpdateMode.Never);

            // Binding quyền hạn (bool → SelectedIndex)
            var bindingQuyen = new Binding("SelectedIndex", bindingSource, "QuyenHan", true, DataSourceUpdateMode.Never);
            bindingQuyen.Format += (s, args) => args.Value = (bool)args.Value ? 0 : 1;
            cboQuyenHan.DataBindings.Add(bindingQuyen);

            dataGridView.DataSource = bindingSource;

            // Ẩn cột nhạy cảm
            if (dataGridView.Columns["ID"] != null) dataGridView.Columns["ID"].Visible = false;
            if (dataGridView.Columns["MatKhau"] != null) dataGridView.Columns["MatKhau"].Visible = false;

            dataGridView.Refresh();
        }
        private void ClearAllBindings()
        {
            txtMaNhanVien.DataBindings.Clear();
            txtHoVaTen.DataBindings.Clear();
            txtDienThoai.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Clear();
            cboQuyenHan.DataBindings.Clear();
        }

        private bool IsPhoneNumber(string number)
        {
            return !string.IsNullOrWhiteSpace(number)
                && number.Length == 10
                && number.StartsWith("0")
                && number.All(char.IsDigit);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            BatTatChucNang(true);

            txtMaNhanVien.Text = MaTuDong.SinhMaNhanVien();
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.SelectedIndex = 1;

            txtHoVaTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isAdding = false;
            BatTatChucNang(true);

            _currentId = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

            txtTenDangNhap.Enabled = false;           // Không cho sửa username
            txtMatKhau.Clear();
            txtMatKhau.PlaceholderText = "Để trống nếu giữ nguyên mật khẩu cũ";

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Validate cơ bản
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            string sdt = txtDienThoai.Text.Trim();
            if (!IsPhoneNumber(sdt))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! (Phải 10 số, bắt đầu bằng 0)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            // 2. Kiểm tra trùng số điện thoại
            bool trungSDT = _isAdding
                ? _context.NhanVien.Any(x => x.DienThoai == sdt)
                : _context.NhanVien.Any(x => x.DienThoai == sdt && x.ID != _currentId);

            if (trungSDT)
            {
                MessageBox.Show("Số điện thoại này đã được sử dụng bởi nhân viên khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenDN = txtTenDangNhap.Text.Trim();

            try
            {
                if (_isAdding)
                {
                    if (_context.NhanVien.Any(x => x.TenDangNhap == tenDN))
                    {
                        MessageBox.Show("Tên đăng nhập này đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        MessageBox.Show("Nhân viên mới bắt buộc phải có mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMatKhau.Focus();
                        return;
                    }

                    var nvMoi = new NhanVien
                    {
                        MaNhanVien = txtMaNhanVien.Text,
                        HoVaTen = txtHoVaTen.Text.Trim(),
                        DienThoai = sdt,
                        DiaChi = txtDiaChi.Text.Trim(),
                        TenDangNhap = tenDN,
                        MatKhau = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text, 12), // work factor 12
                        QuyenHan = cboQuyenHan.SelectedIndex == 0
                    };

                    _context.NhanVien.Add(nvMoi);
                }
                else
                {
                    var nv = _context.NhanVien.Find(_currentId);
                    if (nv == null) return;

                    nv.HoVaTen = txtHoVaTen.Text.Trim();
                    nv.DienThoai = sdt;
                    nv.DiaChi = txtDiaChi.Text.Trim();
                    nv.QuyenHan = cboQuyenHan.SelectedIndex == 0;

                    if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                    {
                        nv.MatKhau = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text, 12);
                    }
                }

                _context.SaveChanges();

                MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BatTatChucNang(false);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ten = txtHoVaTen.Text;
            int idDangChon = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
            int idNguoiDungHienTai = ((frmMain)this.MdiParent).GetCurrentUserId();

            if (idDangChon == idNguoiDungHienTai)
            {
                MessageBox.Show("Bạn không thể tự xóa tài khoản đang đăng nhập của chính mình!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa nhân viên '{ten}' không?\nHành động này không thể hoàn tác.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            string matKhauHash = ((frmMain)this.MdiParent).GetCurrentMatKhauHash();   // ← Gọi hàm từ frmMain

            using (var f = new frmXacNhanXoa($"Bạn có chắc chắn muốn xóa nhân viên '{ten}'?\nHành động này không thể hoàn tác.", matKhauHash))
            {
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            try
            {
                _currentId = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                var nv = _context.NhanVien.Find(_currentId);

                if (nv != null)
                {
                    _context.NhanVien.Remove(nv);
                    _context.SaveChanges();

                    MessageBox.Show("Xóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì họ đã có giao dịch (hóa đơn/phiếu nhập) trong hệ thống!",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel (*.xlsx)|*.xlsx";
            save.FileName = "NhanVien_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    table.Columns.Add("MaNhanVien");
                    table.Columns.Add("HoVaTen");
                    table.Columns.Add("DienThoai");
                    table.Columns.Add("DiaChi");
                    table.Columns.Add("TenDangNhap");
                    table.Columns.Add("MatKhau");
                    table.Columns.Add("QuyenHan");

                    var ds = _context.NhanVien.ToList();

                    foreach (var nv in ds)
                    {
                        table.Rows.Add(
                            nv.MaNhanVien,
                            nv.HoVaTen,
                            nv.DienThoai,
                            nv.DiaChi,
                            nv.TenDangNhap,
                            nv.MatKhau,
                            nv.QuyenHan ? "1" : "0"
                        );
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "NhanVien");

                        sheet.Row(1).Style.Font.Bold = true;
                        sheet.Columns().AdjustToContents();

                        wb.SaveAs(save.FileName);
                    }

                    MessageBox.Show("Xuất Excel thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Excel (*.xlsx)|*.xlsx";

            if (open.ShowDialog() == DialogResult.OK)
            {
                int thanhCong = 0;
                int loi = 0;
                string chiTietLoi = "";

                try
                {
                    using (XLWorkbook wb = new XLWorkbook(open.FileName))
                    {
                        var sheet = wb.Worksheet(1);
                        int rowCount = sheet.LastRowUsed().RowNumber();

                        for (int i = 2; i <= rowCount; i++)
                        {
                            try
                            {
                                string maNV = sheet.Cell(i, 1).GetString().Trim();

                                if (string.IsNullOrEmpty(maNV))
                                    continue;

                                if (_context.NhanVien.Any(x => x.MaNhanVien == maNV))
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: Trùng mã NV\n";
                                    continue;
                                }

                                string tenDN = sheet.Cell(i, 5).GetString();

                                // ❗ tránh trùng tài khoản
                                if (_context.NhanVien.Any(x => x.TenDangNhap == tenDN))
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: Trùng tên đăng nhập\n";
                                    continue;
                                }

                                // xử lý quyền
                                string quyen = sheet.Cell(i, 7).GetString();
                                bool quyenHan = quyen == "1" || quyen.ToLower() == "true";

                                var nv = new NhanVien
                                {
                                    MaNhanVien = maNV,
                                    HoVaTen = sheet.Cell(i, 2).GetString(),
                                    DienThoai = sheet.Cell(i, 3).GetString(),
                                    DiaChi = sheet.Cell(i, 4).GetString(),
                                    TenDangNhap = tenDN,
                                    MatKhau = BCrypt.Net.BCrypt.HashPassword(sheet.Cell(i, 6).GetString()),
                                    QuyenHan = quyenHan
                                };

                                _context.NhanVien.Add(nv);
                                thanhCong++;
                            }
                            catch (Exception exRow)
                            {
                                loi++;
                                chiTietLoi += $"Dòng {i}: {exRow.Message}\n";
                            }
                        }

                        _context.SaveChanges();
                    }

                    MessageBox.Show(
                        $"Nhập thành công: {thanhCong}\nLỗi: {loi}\n\n{chiTietLoi}",
                        "Kết quả import"
                    );

                    frmNhanVien_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi file: " + ex.Message);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.ToLower().Trim();

            var ketQua = _context.NhanVien
                .AsNoTracking()
                .Where(x => x.HoVaTen.ToLower().Contains(keyword) ||
                            x.MaNhanVien.ToLower().Contains(keyword) ||
                            x.DienThoai.Contains(keyword) ||
                            x.TenDangNhap.ToLower().Contains(keyword))
                .ToList();

            HienThiLenLuoi(ketQua);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
