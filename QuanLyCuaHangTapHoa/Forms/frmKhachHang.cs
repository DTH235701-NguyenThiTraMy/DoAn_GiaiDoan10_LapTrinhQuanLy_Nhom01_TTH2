using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyCuaHangTapHoa.Data;
using ClosedXML.Excel;
using System.Data;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmKhachHang : Form
    {
        QLTHDbContext context = new QLTHDbContext();
        bool xuLyThem = false;
        int id;
        public frmKhachHang()
        {
            InitializeComponent();
        }
        // ==================== BẬT/TẮT CHỨC NĂNG ====================
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;

            txtMaKhachHang.Enabled = false;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;            
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
            txtTimKiem.Enabled = !giaTri;
        }
        // ==================== TẢI FORM ====================
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadData();
        }

        private void LoadData()
        {
            // Reset context để lấy dữ liệu mới nhất nếu có thay đổi
            context = new QLTHDbContext();
            List<KhachHang> kh = context.KhachHang.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = kh;

            // Binding các TextBox
            txtMaKhachHang.DataBindings.Clear();
            txtMaKhachHang.DataBindings.Add("Text", bindingSource, "MaKhachHang", false, DataSourceUpdateMode.Never);

            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);

            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;

            // Ẩn cột ID
            if (dataGridView.Columns["ID"] != null)
                dataGridView.Columns["ID"].Visible = false;
        }

        // ==================== NÚT THÊM ====================
        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            txtMaKhachHang.Text = MaTuDong.SinhMaKhachHang();
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
        }

        // ==================== NÚT SỬA ====================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
            txtHoVaTen.Focus();
        }

        // ==================== NÚT XÓA ====================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn dòng nào chưa
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenKH = txtHoVaTen.Text;

            // 2. Hỏi xác nhận cơ bản trước
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng '{tenKH}' không?\nHành động này không thể hoàn tác.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            // 3. Yêu cầu nhập mật khẩu xác nhận (Lấy hash từ Form chính)
            string matKhauHash = ((frmMain)this.MdiParent).GetCurrentMatKhauHash();

            using (var f = new frmXacNhanXoa($"Để bảo mật, vui lòng nhập mật khẩu của bạn để xóa khách hàng '{tenKH}'", matKhauHash))
            {
                // Nếu nhập sai mật khẩu hoặc bấm Hủy thì dừng lại
                if (f.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            // 4. Thực hiện xóa sau khi đã xác thực mật khẩu thành công
            try
            {
                int idXoa = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                var kh = context.KhachHang.Find(idXoa);

                if (kh != null)
                {
                    context.KhachHang.Remove(kh);
                    context.SaveChanges();

                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception)
            {
                // Thông báo lỗi khóa ngoại nếu khách hàng đã có hóa đơn
                MessageBox.Show("Không thể xóa khách hàng này vì họ đã có lịch sử mua hàng (Hóa đơn) trong hệ thống!",
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== NÚT LƯU ====================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoVaTen.Text.Trim();
            string sdt = txtDienThoai.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            // 1. Ràng buộc Tên
            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }

            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            // 2. Ràng buộc SĐT (Độ dài, ký tự số)
            if (string.IsNullOrEmpty(sdt) || sdt.Length != 10 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ! Vui lòng nhập đúng 10 chữ số.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Focus();
                return;
            }

            // 3. Ràng buộc SĐT Duy Nhất
            bool isDuplicatePhone;
            if (xuLyThem)
                isDuplicatePhone = context.KhachHang.Any(x => x.DienThoai == sdt);
            else
                isDuplicatePhone = context.KhachHang.Any(x => x.DienThoai == sdt && x.ID != id); // Cho phép giữ nguyên SĐT cũ của chính người đó

            if (isDuplicatePhone)
            {
                MessageBox.Show("Số điện thoại này đã được đăng ký cho một khách hàng khác!", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDienThoai.Focus();
                return;
            }

            try
            {
                if (xuLyThem)
                {
                    KhachHang kh = new KhachHang
                    {
                        MaKhachHang = txtMaKhachHang.Text,
                        HoVaTen = hoTen,
                        DienThoai = sdt,
                        DiaChi = diaChi
                    };
                    context.KhachHang.Add(kh);
                    MessageBox.Show("Thêm mới khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KhachHang kh = context.KhachHang.Find(id);
                    if (kh != null)
                    {
                        kh.HoVaTen = hoTen;
                        kh.DienThoai = sdt;
                        kh.DiaChi = diaChi;
                        context.KhachHang.Update(kh);
                        MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                context.SaveChanges();
                BatTatChucNang(false);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra trong quá trình lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== NÚT HỦY ====================
        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadData();
        }

        // ==================== NÚT THOÁT ====================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // ==================== XUẤT EXCEL ====================
        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel (*.xlsx)|*.xlsx";
            save.FileName = "KhachHang_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    table.Columns.Add("MaKhachHang");
                    table.Columns.Add("HoVaTen");
                    table.Columns.Add("DienThoai");
                    table.Columns.Add("DiaChi");

                    var ds = context.KhachHang.ToList();

                    foreach (var kh in ds)
                    {
                        table.Rows.Add(
                            kh.MaKhachHang,
                            kh.HoVaTen,
                            kh.DienThoai,
                            kh.DiaChi
                        );
                    }

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "KhachHang");

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

        // ==================== NHẬP EXCEL ====================
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

                        for (int i = 2; i <= rowCount; i++) // Dòng 1 là tiêu đề
                        {
                            try
                            {
                                string maKH = sheet.Cell(i, 1).GetString().Trim();
                                string hoTen = sheet.Cell(i, 2).GetString().Trim();
                                string sdt = sheet.Cell(i, 3).GetString().Trim();
                                string diaChi = sheet.Cell(i, 4).GetString().Trim();

                                if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(hoTen))
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: Mã KH hoặc Tên bị trống\n";
                                    continue;
                                }

                                if (context.KhachHang.Any(x => x.MaKhachHang == maKH))
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: Trùng mã KH\n";
                                    continue;
                                }

                                // Bổ sung kiểm tra SĐT từ file Excel
                                if (string.IsNullOrEmpty(sdt) || sdt.Length != 10 || !sdt.All(char.IsDigit))
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: SĐT không hợp lệ (Phải là 10 chữ số)\n";
                                    continue;
                                }

                                if (context.KhachHang.Any(x => x.DienThoai == sdt))
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: SĐT đã tồn tại trong hệ thống\n";
                                    continue;
                                }

                                var kh = new KhachHang
                                {
                                    MaKhachHang = maKH,
                                    HoVaTen = hoTen,
                                    DienThoai = sdt,
                                    DiaChi = diaChi
                                };

                                context.KhachHang.Add(kh);
                                thanhCong++;
                            }
                            catch (Exception exRow)
                            {
                                loi++;
                                chiTietLoi += $"Dòng {i}: {exRow.Message}\n";
                            }
                        }
                        context.SaveChanges();
                    }

                    // Tách thông báo thành 2 trường hợp để nhìn gọn gàng hơn
                    if (loi == 0)
                    {
                        MessageBox.Show($"Đã nhập thành công {thanhCong} khách hàng!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Nhập thành công: {thanhCong}\nLỗi: {loi}\n\nChi tiết lỗi:\n{chiTietLoi}", "Kết quả Import", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đọc file Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();

            var ketQua = context.KhachHang
                .Where(k => k.HoVaTen.ToLower().Contains(tuKhoa) ||
                            k.DienThoai.Contains(tuKhoa) ||
                            k.MaKhachHang.ToLower().Contains(tuKhoa))
                .ToList();

            // Cập nhật lại lưới ngay lập tức
            CapNhatGiaoDienTimKiem(ketQua);
        }

        private void CapNhatGiaoDienTimKiem(List<KhachHang> danhSachLoc)
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = danhSachLoc;

            // Phải xóa Binding cũ để tránh lỗi xung đột dữ liệu
            txtMaKhachHang.DataBindings.Clear();
            txtHoVaTen.DataBindings.Clear();
            txtDienThoai.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();

            // Gán Binding mới theo danh sách đã lọc
            txtMaKhachHang.DataBindings.Add("Text", bindingSource, "MaKhachHang", false, DataSourceUpdateMode.Never);
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LoadData();
        }
    }
}
