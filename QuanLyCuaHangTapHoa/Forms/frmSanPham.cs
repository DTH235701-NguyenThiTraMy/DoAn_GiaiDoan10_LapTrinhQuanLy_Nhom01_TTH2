using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyCuaHangTapHoa.Data;
using System.Linq;
using ClosedXML.Excel;
using System.Data;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmSanPham : Form
    {
        QLTHDbContext context = new QLTHDbContext();
        bool xuLyThem = false;
        int id;
        string imagesFolder = Application.StartupPath.Replace("bin\\Debug\\net8.0-windows", "Images");
        public frmSanPham()
        {
            InitializeComponent();
        }
        private void BatTatChucNang(bool giaTri)
        {
            btnLuu.Enabled = giaTri;
            btnHuy.Enabled = giaTri;

            txtMaSanPham.Enabled = giaTri;
            txtTenSanPham.Enabled = giaTri;
            numSoLuongTon.Enabled = giaTri;
            numDonGiaBan.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;
            btnDoiAnh.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnTim.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;

            List<SanPham> sp = context.SanPham.ToList();

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = sp;

            // Binding
            txtMaSanPham.DataBindings.Clear();
            txtMaSanPham.DataBindings.Add("Text", bindingSource, "MaSanPham", false, DataSourceUpdateMode.Never);

            txtTenSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Add("Text", bindingSource, "TenSanPham", false, DataSourceUpdateMode.Never);

            numSoLuongTon.DataBindings.Clear();
            numSoLuongTon.DataBindings.Add("Value", bindingSource, "SoLuongTon", false, DataSourceUpdateMode.Never);

            numDonGiaBan.DataBindings.Clear();
            numDonGiaBan.DataBindings.Add("Value", bindingSource, "DonGiaBan", false, DataSourceUpdateMode.Never);

            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bindingSource, "MoTa", false, DataSourceUpdateMode.Never);

            // Hình ảnh cho PictureBox
            picHinhAnh.DataBindings.Clear();
            Binding hinhAnhBinding = new Binding("ImageLocation", bindingSource, "HinhAnh");
            hinhAnhBinding.Format += (s, ev) =>
            {
                if (ev.Value != null)
                    ev.Value = Path.Combine(imagesFolder, ev.Value.ToString());
            };
            picHinhAnh.DataBindings.Add(hinhAnhBinding);

            dataGridView.DataSource = bindingSource;

            // Ẩn cột ID
            if (dataGridView.Columns["ID"] != null)
                dataGridView.Columns["ID"].Visible = false;
        }
        // ==================== HIỂN THỊ ẢNH NHỎ TRONG DATAGRIDVIEW ====================
        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "HinhAnh" && e.Value != null)
            {
                try
                {
                    string fullPath = Path.Combine(imagesFolder, e.Value.ToString());
                    if (File.Exists(fullPath))
                    {
                        Image img = Image.FromFile(fullPath);
                        e.Value = new Bitmap(img, 40, 40);  // ảnh nhỏ 40x40
                    }
                }
                catch { e.Value = null; }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xuLyThem = true;
            BatTatChucNang(true);

            txtMaSanPham.Text = MaTuDong.SinhMaSanPham();
            txtTenSanPham.Clear();
            txtMoTa.Clear();
            numSoLuongTon.Value = 0;
            numDonGiaBan.Value = 0;
            picHinhAnh.Image = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xuLyThem = false;
            BatTatChucNang(true);
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numSoLuongTon.Value <= 0)
            {
                MessageBox.Show("Số lượng tồn phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numDonGiaBan.Value <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (xuLyThem)
            {
                SanPham sp = new SanPham
                {
                    MaSanPham = txtMaSanPham.Text,
                    TenSanPham = txtTenSanPham.Text,
                    SoLuongTon = (int)numSoLuongTon.Value,
                    DonGiaBan = (int)numDonGiaBan.Value,
                    MoTa = txtMoTa.Text,
                    HinhAnh = picHinhAnh.Image != null ? Path.GetFileName(picHinhAnh.ImageLocation) : null
                };
                context.SanPham.Add(sp);
            }
            else
            {
                SanPham sp = context.SanPham.Find(id);
                if (sp != null)
                {
                    sp.MaSanPham = txtMaSanPham.Text;
                    sp.TenSanPham = txtTenSanPham.Text;
                    sp.SoLuongTon = (int)numSoLuongTon.Value;
                    sp.DonGiaBan = (int)numDonGiaBan.Value;
                    sp.MoTa = txtMoTa.Text;
                    if (picHinhAnh.Image != null)
                        sp.HinhAnh = Path.GetFileName(picHinhAnh.ImageLocation);
                }
            }

            context.SaveChanges();
            frmSanPham_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận xóa sản phẩm " + txtTenSanPham.Text + "?", "Xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                SanPham sp = context.SanPham.Find(id);
                if (sp != null) context.SanPham.Remove(sp);

                context.SaveChanges();
                frmSanPham_Load(sender, e);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmSanPham_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(dlg.FileName);
                string destPath = Path.Combine(imagesFolder, fileName);

                // Nếu file đã tồn tại thì thêm số
                if (File.Exists(destPath))
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_" +
                               DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fileName);
                    destPath = Path.Combine(imagesFolder, fileName);
                }

                File.Copy(dlg.FileName, destPath, true);

                picHinhAnh.ImageLocation = destPath;

                // Nếu đang sửa thì cập nhật luôn vào DB
                if (!xuLyThem && dataGridView.CurrentRow != null)
                {
                    id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
                    SanPham sp = context.SanPham.Find(id);
                    if (sp != null)
                    {
                        sp.HinhAnh = fileName;
                        context.SaveChanges();
                    }
                }
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Xuất dữ liệu ra Excel";
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "SanPham_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    DataTable table = new DataTable();

                    // Tạo cột
                    table.Columns.Add("MaSanPham");
                    table.Columns.Add("TenSanPham");
                    table.Columns.Add("DonGiaBan");
                    table.Columns.Add("SoLuongTon");
                    table.Columns.Add("HinhAnh");
                    table.Columns.Add("MoTa");

                    // Lấy dữ liệu
                    var ds = context.SanPham.ToList();

                    foreach (var sp in ds)
                    {
                        table.Rows.Add(
                            sp.MaSanPham,
                            sp.TenSanPham,
                            sp.DonGiaBan,
                            sp.SoLuongTon,
                            sp.HinhAnh,
                            sp.MoTa
                        );
                    }

                    // Xuất Excel
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        var sheet = wb.Worksheets.Add(table, "SanPham");

                        // Tự động chỉnh cột
                        sheet.Columns().AdjustToContents();

                        wb.SaveAs(saveFileDialog.FileName);
                    }

                    MessageBox.Show("Xuất Excel thành công!", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                int thanhCong = 0;
                int loi = 0;
                string chiTietLoi = "";

                try
                {
                    using (XLWorkbook wb = new XLWorkbook(openFileDialog.FileName))
                    {
                        var sheet = wb.Worksheet(1);
                        int rowCount = sheet.LastRowUsed().RowNumber();

                        for (int i = 2; i <= rowCount; i++)
                        {
                            try
                            {
                                string maSP = sheet.Cell(i, 1).GetString().Trim();

                                // ❗ bỏ dòng trống
                                if (string.IsNullOrEmpty(maSP))
                                    continue;

                                // ❗ trùng mã
                                if (context.SanPham.Any(x => x.MaSanPham == maSP))
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: Trùng mã sản phẩm\n";
                                    continue;
                                }

                                // đọc dữ liệu
                                string tenSP = sheet.Cell(i, 2).GetString();
                                bool checkGia = int.TryParse(sheet.Cell(i, 3).GetString(), out int gia);
                                bool checkSL = int.TryParse(sheet.Cell(i, 4).GetString(), out int sl);

                                if (!checkGia || !checkSL)
                                {
                                    loi++;
                                    chiTietLoi += $"Dòng {i}: Sai định dạng số\n";
                                    continue;
                                }

                                var sp = new SanPham
                                {
                                    MaSanPham = maSP,
                                    TenSanPham = tenSP,
                                    DonGiaBan = gia,
                                    SoLuongTon = sl,
                                    HinhAnh = sheet.Cell(i, 5).GetString(),
                                    MoTa = sheet.Cell(i, 6).GetString()
                                };

                               context.SanPham.Add(sp);
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
                        $"Nhập thành công: {thanhCong}\n" +
                        $"Lỗi: {loi}\n\n" +
                        (loi > 0 ? chiTietLoi : ""),
                        "Kết quả import",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    frmSanPham_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi file: " + ex.Message);
                }
            }
        }
    }
}
