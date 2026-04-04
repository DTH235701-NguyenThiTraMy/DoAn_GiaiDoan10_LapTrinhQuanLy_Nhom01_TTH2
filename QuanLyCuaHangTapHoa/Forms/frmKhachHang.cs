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

            txtMaKhachHang.Enabled = giaTri;   // tạm thời cho sửa
            txtHoVaTen.Enabled = giaTri;
            txtDienThoai.Enabled = giaTri;
            txtDiaChi.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTim.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }
        // ==================== TẢI FORM ====================
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            txtMaKhachHang.Text = MaTuDong.SinhMaKhachHang();
            txtHoVaTen.Clear();
            txtDienThoai.Clear();
            txtDiaChi.Clear();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa khách hàng " + txtHoVaTen.Text + "?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                KhachHang kh = context.KhachHang.Find(id);

                if (kh != null)
                    context.KhachHang.Remove(kh);

                context.SaveChanges();
                frmKhachHang_Load(sender, e);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoVaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng?", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (xuLyThem)
            {
                KhachHang kh = new KhachHang();
                kh.MaKhachHang = txtMaKhachHang.Text;   // tạm thời (sau mình sẽ tự động sinh)
                kh.HoVaTen = txtHoVaTen.Text;
                kh.DienThoai = txtDienThoai.Text;
                kh.DiaChi = txtDiaChi.Text;

                context.KhachHang.Add(kh);
            }
            else
            {
                KhachHang kh = context.KhachHang.Find(id);
                if (kh != null)
                {
                    kh.MaKhachHang = txtMaKhachHang.Text;
                    kh.HoVaTen = txtHoVaTen.Text;
                    kh.DienThoai = txtDienThoai.Text;
                    kh.DiaChi = txtDiaChi.Text;

                    context.KhachHang.Update(kh);
                }
            }

            context.SaveChanges();
            frmKhachHang_Load(sender, e);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmKhachHang_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                                string maKH = sheet.Cell(i, 1).GetString().Trim();

                                if (string.IsNullOrEmpty(maKH))
                                    continue;

                                if (context.KhachHang.Any(x => x.MaKhachHang == maKH))
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: Trùng mã KH\n";
                                    continue;
                                }
                                var kh = new KhachHang
                                {
                                    MaKhachHang = maKH,
                                    HoVaTen = sheet.Cell(i, 2).GetString(),
                                    DienThoai = sheet.Cell(i, 3).GetString(),
                                    DiaChi = sheet.Cell(i, 4).GetString()
                                };
                                if (kh.DienThoai.Length < 10 || kh.DienThoai.Length > 10)
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: SĐT không hợp lệ\n";
                                    continue;
                                }
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

                    MessageBox.Show(
                        $"Nhập thành công: {thanhCong}\nLỗi: {loi}\n\n{chiTietLoi}",
                        "Kết quả import"
                    );

                    frmKhachHang_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi file: " + ex.Message);
                }
            }
        }
    }
}
