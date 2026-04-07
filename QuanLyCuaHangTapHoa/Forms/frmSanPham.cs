using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTapHoa.Data;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmSanPham : Form
    {
        private readonly QLTHDbContext _context;
        private readonly BindingSource bs = new BindingSource();
        private bool _isAdding = false;
        private int _currentId = 0;

        // Đường dẫn Images an toàn hơn (không dùng Replace cứng)
        private readonly string _imagesFolder;

        public frmSanPham()
        {
            InitializeComponent();

            _context = new QLTHDbContext();

            _imagesFolder = Path.Combine(Application.StartupPath, "..", "..", "..", "Images");
            if (!Directory.Exists(_imagesFolder))
                Directory.CreateDirectory(_imagesFolder);
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            dataGridView.AutoGenerateColumns = false;
            dataGridView.DataSource = bs;        // Gán 1 lần duy nhất
            LoadDataToGrid();
        }

        private void LoadDataToGrid(string keyword = "")
        {
            var query = _context.SanPham.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.ToLower().Trim();
                query = query.Where(x => x.TenSanPham.ToLower().Contains(keyword) ||
                                         x.MaSanPham.ToLower().Contains(keyword) ||
                                         (x.MoTa != null && x.MoTa.ToLower().Contains(keyword)));
            }

            var ds = query.ToList();
            bs.DataSource = ds;

            RefreshBindings();
        }

        private void RefreshBindings()
        {
            // Xóa bindings cũ
            txtMaSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Clear();
            numSoLuongTon.DataBindings.Clear();
            numDonGiaBan.DataBindings.Clear();
            txtMoTa.DataBindings.Clear();
            picHinhAnh.DataBindings.Clear();

            // Binding mới
            txtMaSanPham.DataBindings.Add("Text", bs, "MaSanPham", false, DataSourceUpdateMode.Never);
            txtTenSanPham.DataBindings.Add("Text", bs, "TenSanPham", false, DataSourceUpdateMode.Never);
            numSoLuongTon.DataBindings.Add("Value", bs, "SoLuongTon", true, DataSourceUpdateMode.Never);
            numDonGiaBan.DataBindings.Add("Value", bs, "DonGiaBan", true, DataSourceUpdateMode.Never);
            txtMoTa.DataBindings.Add("Text", bs, "MoTa", false, DataSourceUpdateMode.Never);

            // Binding ảnh an toàn
            var imgBinding = new Binding("ImageLocation", bs, "HinhAnh", true, DataSourceUpdateMode.Never);
            imgBinding.Format += (s, e) =>
            {
                if (e.Value != null && !string.IsNullOrEmpty(e.Value.ToString()))
                {
                    string path = Path.Combine(_imagesFolder, e.Value.ToString());
                    e.Value = File.Exists(path) ? path : null;
                }
            };
            picHinhAnh.DataBindings.Add(imgBinding);

            if (dataGridView.Columns["ID"] != null)
                dataGridView.Columns["ID"].Visible = false;
        }

        private void BatTatChucNang(bool choPhep)
        {
            btnLuu.Enabled = choPhep;
            btnHuy.Enabled = choPhep;

            txtMaSanPham.Enabled = choPhep && _isAdding;   // ← Sửa quan trọng
            txtTenSanPham.Enabled = choPhep;
            numSoLuongTon.Enabled = choPhep;
            numDonGiaBan.Enabled = choPhep;
            txtMoTa.Enabled = choPhep;
            picHinhAnh.Enabled = choPhep;
            btnDoiAnh.Enabled = choPhep;

            btnThem.Enabled = !choPhep;
            btnSua.Enabled = !choPhep;
            btnXoa.Enabled = !choPhep;
            btnNhap.Enabled = !choPhep;
            btnXuat.Enabled = !choPhep;
            txtTimKiem.Enabled = !choPhep;
        }

        // ====================== VALIDATION ======================
        private bool ValidateInput()
        {
            string tenSP = txtTenSanPham.Text.Trim();

            // 1. Tên sản phẩm
            if (string.IsNullOrEmpty(tenSP))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return false;
            }

            if (tenSP.Length < 3 || tenSP.Length > 150)
            {
                MessageBox.Show("Tên sản phẩm phải từ 3 đến 150 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSanPham.Focus();
                return false;
            }

            // 2. Kiểm tra trùng tên sản phẩm
            //bool trungTen = _isAdding
            //    ? _context.SanPham.Any(x => x.TenSanPham == tenSP)
            //    : _context.SanPham.Any(x => x.TenSanPham == tenSP && x.ID != _currentId);

            //if (trungTen)
            //{
            //    MessageBox.Show("Tên sản phẩm này đã tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtTenSanPham.Focus();
            //    return false;
            //}

            // 3. Đơn giá (bắt buộc > 0)
            if (numDonGiaBan.Value <= 1000)
            {
                MessageBox.Show("Đơn giá bán phải lớn hơn 1000!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDonGiaBan.Focus();
                return false;
            }

            if (numDonGiaBan.Value > 100_000_000)
            {
                MessageBox.Show("Đơn giá không được vượt quá 100 triệu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numDonGiaBan.Focus();
                return false;
            }

            // 4. Số lượng tồn (cho phép = 0)
            if (numSoLuongTon.Value < 0 || numSoLuongTon.Value > 10_000)
            {
                MessageBox.Show("Số lượng tồn phải từ 0 đến 10.000!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numSoLuongTon.Focus();
                return false;
            }

            // 5. Hình ảnh KHÔNG bắt buộc
            // if (picHinhAnh.ImageLocation == null)
            // {
            //     MessageBox.Show("Vui lòng chọn hình ảnh cho sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //     btnDoiAnh.Focus();
            //     return false;
            // }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _isAdding = true;
            BatTatChucNang(true);

            txtMaSanPham.Text = MaTuDong.SinhMaSanPham();
            txtTenSanPham.Clear();
            txtMoTa.Clear();
            numSoLuongTon.Value = 0;
            numDonGiaBan.Value = 0;
            picHinhAnh.Image = null;
            picHinhAnh.ImageLocation = null;

            txtTenSanPham.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isAdding = false;
            BatTatChucNang(true);
            _currentId = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                if (_isAdding)
                {
                    var sp = new SanPham
                    {
                        MaSanPham = txtMaSanPham.Text.Trim(),
                        TenSanPham = txtTenSanPham.Text.Trim(),
                        DonGiaBan = (int)(decimal)numDonGiaBan.Value,     // Nên cast decimal
                        SoLuongTon = (int)numSoLuongTon.Value,
                        MoTa = txtMoTa.Text.Trim(),
                        HinhAnh = picHinhAnh.ImageLocation != null ? Path.GetFileName(picHinhAnh.ImageLocation) : null
                    };
                    _context.SanPham.Add(sp);
                }
                else
                {
                    var sp = _context.SanPham.Find(_currentId);
                    if (sp == null) return;

                    sp.TenSanPham = txtTenSanPham.Text.Trim();
                    sp.DonGiaBan = (int)(decimal)numDonGiaBan.Value;
                    sp.SoLuongTon = (int)numSoLuongTon.Value;
                    sp.MoTa = txtMoTa.Text.Trim();

                    if (!string.IsNullOrEmpty(picHinhAnh.ImageLocation))
                        sp.HinhAnh = Path.GetFileName(picHinhAnh.ImageLocation);
                }

                _context.SaveChanges();
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                BatTatChucNang(false);
                LoadDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn chắc chắn muốn xóa sản phẩm '{txtTenSanPham.Text}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _currentId = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

                if (_context.HoaDon_ChiTiet.Any(x => x.SanPhamID == _currentId) ||
                    _context.PhieuNhap_ChiTiet.Any(x => x.SanPhamID == _currentId))
                {
                    MessageBox.Show("Không thể xóa! Sản phẩm đã phát sinh giao dịch.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var sp = _context.SanPham.Find(_currentId);
                if (sp != null)
                {
                    _context.SanPham.Remove(sp);
                    _context.SaveChanges();
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            BatTatChucNang(false);
            LoadDataToGrid();
        }

        private void btnThoat_Click(object sender, EventArgs e) => this.Close();

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDataToGrid();
        }

        private void btnDoiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    string fileName = Path.GetFileName(dlg.FileName);
                    string destPath = Path.Combine(_imagesFolder, fileName);

                    if (File.Exists(destPath))
                    {
                        fileName = Path.GetFileNameWithoutExtension(fileName) + "_" +
                                   DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(fileName);
                        destPath = Path.Combine(_imagesFolder, fileName);
                    }

                    File.Copy(dlg.FileName, destPath, true);
                    picHinhAnh.ImageLocation = destPath;
                    picHinhAnh.Image = Image.FromFile(destPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message);
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadDataToGrid(txtTimKiem.Text);
            txtTimKiem.Clear();
        }

        // ====================== EXPORT / IMPORT (giữ nguyên, bạn có thể tinh chỉnh sau) ======================
        // ... (phần btnXuat_Click và btnNhap_Click bạn giữ nguyên cũng được)

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView.Columns[e.ColumnIndex].Name != "HinhAnh" || e.Value == null)
                return;

            try
            {
                string fullPath = Path.Combine(_imagesFolder, e.Value.ToString());
                if (File.Exists(fullPath))
                {
                    using (var img = Image.FromFile(fullPath))
                        e.Value = new Bitmap(img, 40, 40);
                }
            }
            catch
            {
                e.Value = null;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
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
                    var ds = _context.SanPham.ToList();
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
                                if (_context.SanPham.Any(x => x.MaSanPham == maSP))
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
                                _context.SanPham.Add(sp);
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