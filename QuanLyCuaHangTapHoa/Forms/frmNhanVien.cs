using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyCuaHangTapHoa.Data;
using ClosedXML.Excel;
using System.Data;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmNhanVien : Form
    {
        QLTHDbContext context = new QLTHDbContext();
        bool xuLyThem = false;
        int id;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;

            txtMaNhanVien.Enabled = giaTri;
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;
            txtTenDangNhap.Enabled = giaTri;
            txtMatKhau.Enabled = giaTri;
            cboQuyenHan.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTim.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;

            List<NhanVien> nv = context.NhanVien.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = nv;

            // Binding
            txtMaNhanVien.DataBindings.Clear();
            txtMaNhanVien.DataBindings.Add("Text", bindingSource, "MaNhanVien", false, DataSourceUpdateMode.Never);

            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", bindingSource, "HoVaTen", false, DataSourceUpdateMode.Never);

            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", bindingSource, "DienThoai", false, DataSourceUpdateMode.Never);

            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", bindingSource, "DiaChi", false, DataSourceUpdateMode.Never);

            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add("Text", bindingSource, "TenDangNhap", false, DataSourceUpdateMode.Never);

            cboQuyenHan.DataBindings.Clear();
            cboQuyenHan.DataBindings.Add("SelectedIndex", bindingSource, "QuyenHan", false, DataSourceUpdateMode.Never);

            dataGridView.DataSource = bindingSource;

            // Ẩn cột ID
            if (dataGridView.Columns["ID"] != null)
                dataGridView.Columns["ID"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            txtMaNhanVien.Text = MaTuDong.SinhMaNhanVien();
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
            txtTenDangNhap.Clear();
            txtMatKhau.Clear();
            cboQuyenHan.SelectedIndex = -1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboQuyenHan.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn quyền hạn?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (xuLyThem)
            {
                if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                NhanVien nv = new NhanVien();
                nv.MaNhanVien = txtMaNhanVien.Text;           // sau sẽ tự động sinh
                nv.HoVaTen = txtHoVaTen.Text;
                nv.DienThoai = txtDienThoai.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.TenDangNhap = txtTenDangNhap.Text;
                nv.MatKhau = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);
                nv.QuyenHan = cboQuyenHan.SelectedIndex == 0;

                context.NhanVien.Add(nv);
            }
            else
            {
                NhanVien nv = context.NhanVien.Find(id);
                if (nv != null)
                {
                    nv.MaNhanVien = txtMaNhanVien.Text;
                    nv.HoVaTen = txtHoVaTen.Text;
                    nv.DienThoai = txtDienThoai.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.TenDangNhap = txtTenDangNhap.Text;
                    nv.QuyenHan = cboQuyenHan.SelectedIndex == 0;

                    if (!string.IsNullOrWhiteSpace(txtMatKhau.Text))
                        nv.MatKhau = BCrypt.Net.BCrypt.HashPassword(txtMatKhau.Text);

                    context.NhanVien.Update(nv);
                }
            }

            context.SaveChanges();
            frmNhanVien_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa nhân viên " + txtHoVaTen.Text + "?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                NhanVien nv = context.NhanVien.Find(id);
                if (nv != null) context.NhanVien.Remove(nv);

                context.SaveChanges();
                frmNhanVien_Load(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(sender, e);
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

                    var ds = context.NhanVien.ToList();

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

                                if (context.NhanVien.Any(x => x.MaNhanVien == maNV))
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: Trùng mã NV\n";
                                    continue;
                                }

                                string tenDN = sheet.Cell(i, 5).GetString();

                                // ❗ tránh trùng tài khoản
                                if (context.NhanVien.Any(x => x.TenDangNhap == tenDN))
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

                                context.NhanVien.Add(nv);
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

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}
