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

            txtMaSanPham.Enabled = false;
            txtTenSanPham.Enabled = giaTri;
            numSoLuongTon.Enabled = giaTri;
            numDonGiaBan.Enabled = giaTri;
            txtMoTa.Enabled = giaTri;
            picHinhAnh.Enabled = giaTri;
            btnDoiAnh.Enabled = giaTri;

            btnThem.Enabled = !giaTri;
            btnSua.Enabled = !giaTri;
            btnXoa.Enabled = !giaTri;
            btnNhap.Enabled = !giaTri;
            btnXuat.Enabled = !giaTri;
            txtTimKiem.Enabled = !giaTri;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadData();
        }

        private void LoadData()
        {
            context.Dispose();
            context = new QLTHDbContext();

            var sp = context.SanPham.ToList();
            HienThiLenLuoi(sp);
        }

        private void HienThiLenLuoi(List<SanPham> ds)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ds;

            txtMaSanPham.DataBindings.Clear();
            txtMaSanPham.DataBindings.Add("Text", bs, "MaSanPham");

            txtTenSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Add("Text", bs, "TenSanPham");

            numSoLuongTon.DataBindings.Clear();
            numSoLuongTon.DataBindings.Add("Value", bs, "SoLuongTon");

            numDonGiaBan.DataBindings.Clear();
            numDonGiaBan.DataBindings.Add("Value", bs, "DonGiaBan");

            txtMoTa.DataBindings.Clear();
            txtMoTa.DataBindings.Add("Text", bs, "MoTa");

            // Ảnh
            picHinhAnh.DataBindings.Clear();
            Binding img = new Binding("ImageLocation", bs, "HinhAnh");
            img.Format += (s, e) =>
            {
                if (e.Value != null)
                    e.Value = Path.Combine(imagesFolder, e.Value.ToString());
            };
            picHinhAnh.DataBindings.Add(img);

            dataGridView.DataSource = bs;

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

            txtTenSanPham.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Chọn sản phẩm!");
                return;
            }

            xuLyThem = false;
            BatTatChucNang(true);

            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenSanPham.Text))
            {
                MessageBox.Show("Nhập tên sản phẩm!");
                return;
            }

            if (numDonGiaBan.Value <= 0)
            {
                MessageBox.Show("Giá phải > 0!");
                return;
            }

            if (numSoLuongTon.Value < 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            string ma = txtMaSanPham.Text.Trim();

            if (xuLyThem && context.SanPham.Any(x => x.MaSanPham == ma))
            {
                MessageBox.Show("Trùng mã sản phẩm!");
                return;
            }

            try
            {
                if (xuLyThem)
                {
                    var sp = new SanPham
                    {
                        MaSanPham = ma,
                        TenSanPham = txtTenSanPham.Text,
                        DonGiaBan = (int)numDonGiaBan.Value,
                        SoLuongTon = (int)numSoLuongTon.Value,
                        MoTa = txtMoTa.Text,
                        HinhAnh = picHinhAnh.Image != null
                            ? Path.GetFileName(picHinhAnh.ImageLocation)
                            : null
                    };

                    context.SanPham.Add(sp);
                }
                else
                {
                    var sp = context.SanPham.Find(id);

                    if (sp != null)
                    {
                        sp.TenSanPham = txtTenSanPham.Text;
                        sp.DonGiaBan = (int)numDonGiaBan.Value;
                        sp.SoLuongTon = (int)numSoLuongTon.Value;
                        sp.MoTa = txtMoTa.Text;

                        if (picHinhAnh.Image != null)
                            sp.HinhAnh = Path.GetFileName(picHinhAnh.ImageLocation);
                    }
                }

                context.SaveChanges();

                MessageBox.Show("Lưu thành công!");
                BatTatChucNang(false);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Chọn sản phẩm!");
                return;
            }

            if (MessageBox.Show("Bạn chắc chắn xóa?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                int id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

                // ❗ check FK
                bool daBan = context.HoaDon_ChiTiet.Any(x => x.SanPhamID == id);
                bool daNhap = context.PhieuNhap_ChiTiet.Any(x => x.SanPhamID == id);

                if (daBan || daNhap)
                {
                    MessageBox.Show("Không thể xóa! Sản phẩm đã phát sinh giao dịch.");
                    return;
                }

                var sp = context.SanPham.Find(id);

                if (sp != null)
                {
                    context.SanPham.Remove(sp);
                    context.SaveChanges();
                    MessageBox.Show("Đã xóa!");
                }

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.ToLower();

            var ds = context.SanPham
                .Where(x => x.TenSanPham.ToLower().Contains(tuKhoa)
                         || x.MaSanPham.ToLower().Contains(tuKhoa))
                .ToList();

            dataGridView.DataSource = ds;
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
