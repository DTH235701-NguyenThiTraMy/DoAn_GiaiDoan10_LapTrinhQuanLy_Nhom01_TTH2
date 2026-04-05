using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using QuanLyCuaHangTapHoa.Data;
using QuanLyCuaHangTapHoa.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static QuanLyCuaHangTapHoa.Data.HoaDon;

namespace QuanLyCuaHangTapHoa.Forms
{
    public partial class frmHoaDon : Form
    {
        QLTHDbContext db = new QLTHDbContext();
        int id;

        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {            
            dataGridView.AutoGenerateColumns = false;
            LoadData();
        }

        // --- HÀM NẠP DỮ LIỆU & TÌM KIẾM ---
        private void LoadData(string keyword = "")
        {
            try
            {
                using (var db = new QLTHDbContext())
                {
                    var query = db.HoaDon
                        .Include(r => r.NhanVien)
                        .Include(r => r.KhachHang)
                        .AsNoTracking()
                        .AsQueryable();

                    // Xử lý tìm kiếm đa năng
                    if (!string.IsNullOrWhiteSpace(keyword))
                    {
                        keyword = keyword.ToLower();
                        query = query.Where(r =>
                            r.MaHoaDon.ToLower().Contains(keyword) ||
                            (r.KhachHang != null && r.KhachHang.HoVaTen.ToLower().Contains(keyword)) ||
                            r.NhanVien.HoVaTen.ToLower().Contains(keyword));
                    }

                    var ds = query.Select(r => new
                    {
                        r.ID,
                        r.MaHoaDon,
                        HoVaTenNhanVien = r.NhanVien.HoVaTen,
                        HoVaTenKhachHang = r.KhachHang != null ? r.KhachHang.HoVaTen : "Khách lẻ",
                        r.NgayLap,
                        TongTienHoaDon = r.HoaDon_ChiTiet.Sum(c => c.SoLuongBan * c.DonGiaBan),
                        XemChiTiet = "Xem chi tiết"
                    }).ToList();

                    dataGridView.DataSource = ds;
                    
                    lblStatus.Text = string.IsNullOrEmpty(keyword)
                        ? $"Tổng số: {ds.Count} hóa đơn."
                        : $"Tìm thấy {ds.Count} kết quả cho '{keyword}'.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi nạp dữ liệu: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtTim.Text.Trim());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTim.Clear();
            LoadData();
        }

        // ================= NÚT LẬP HÓA ĐƠN =================
        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            using (frmHoaDon_ChiTiet f = new frmHoaDon_ChiTiet())
            {
                f.ShowDialog();
            }
            frmHoaDon_Load(sender, e);
        }

        // ================= NÚT SỬA =================
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;
            id = Convert.ToInt32(dataGridView.CurrentRow.Cells["ID"].Value);

            using (frmHoaDon_ChiTiet f = new frmHoaDon_ChiTiet(id))
            {
                f.ShowDialog();
            }

            LoadData();
        }

        // ================= NÚT XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null) return;

            string maHD = dataGridView.CurrentRow.Cells["MaHoaDon"].Value.ToString();

            var result = MessageBox.Show($"Xác nhận xóa hóa đơn: {maHD}?\nLưu ý: Hệ thống sẽ tự động hoàn trả số lượng hàng vào kho.",
                                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int deleteId = (int)dataGridView.CurrentRow.Cells["ID"].Value;
                    using (var db = new QLTHDbContext())
                    {
                        var hd = db.HoaDon.Include(h => h.HoaDon_ChiTiet).FirstOrDefault(h => h.ID == deleteId);
                        if (hd != null)
                        {
                            foreach (var item in hd.HoaDon_ChiTiet)
                            {
                                var sp = db.SanPham.Find(item.SanPhamID);
                                if (sp != null) sp.SoLuongTon += item.SoLuongBan;
                            }
                            db.HoaDon_ChiTiet.RemoveRange(hd.HoaDon_ChiTiet);
                            db.HoaDon.Remove(hd);
                            db.SaveChanges();

                            MessageBox.Show($"Đã xóa hóa đơn {maHD} thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể xóa hóa đơn. Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }               

        // ================= NÚT XUẤT =================
        private void btnXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel (*.xlsx)|*.xlsx";
            save.FileName = $"HoaDon_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var db = new QLTHDbContext())
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // --- SHEET 1: HÓA ĐƠN ---
                        var dtHoaDon = new DataTable("HoaDon");
                        dtHoaDon.Columns.AddRange(new DataColumn[] {
                            new DataColumn("Mã Hóa Đơn"),
                            new DataColumn("Nhân Viên"),
                            new DataColumn("Khách Hàng"),
                            new DataColumn("Ngày Lập"),
                            new DataColumn("Tổng Tiền", typeof(decimal))
                        });

                        var dsHoaDon = db.HoaDon.Include(h => h.NhanVien).Include(h => h.KhachHang).Include(h => h.HoaDon_ChiTiet).ToList();
                        foreach (var hd in dsHoaDon)
                        {
                            dtHoaDon.Rows.Add(
                                hd.MaHoaDon,
                                hd.NhanVien?.HoVaTen ?? "N/A",
                                hd.KhachHang?.HoVaTen ?? "Khách lẻ", // Tránh lỗi Null ở đây
                                hd.NgayLap.ToString("dd/MM/yyyy"),
                                hd.HoaDon_ChiTiet.Sum(x => x.SoLuongBan * x.DonGiaBan)
                            );
                        }
                        wb.Worksheets.Add(dtHoaDon).Columns().AdjustToContents();

                        // --- SHEET 2: CHI TIẾT ---
                        var dtCT = new DataTable("ChiTiet");
                        dtCT.Columns.AddRange(new DataColumn[] {
                            new DataColumn("Mã Hóa Đơn"),
                            new DataColumn("Sản Phẩm"),
                            new DataColumn("Số Lượng"),
                            new DataColumn("Đơn Giá"),
                            new DataColumn("Thành Tiền")
                        });

                        var dsCT = db.HoaDon_ChiTiet.Include(c => c.HoaDon).Include(c => c.SanPham).ToList();
                        foreach (var ct in dsCT)
                        {
                            dtCT.Rows.Add(
                                ct.HoaDon.MaHoaDon,
                                ct.SanPham.TenSanPham,
                                ct.SoLuongBan,
                                ct.DonGiaBan,
                                ct.SoLuongBan * ct.DonGiaBan
                            );
                        }
                        wb.Worksheets.Add(dtCT).Columns().AdjustToContents();

                        wb.SaveAs(save.FileName);
                        MessageBox.Show("Xuất dữ liệu Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
                }
            }
        }

        // ================= NÚT IN HÓA ĐƠN =================
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để thực hiện in!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int printId = (int)dataGridView.CurrentRow.Cells["ID"].Value;

            // Mở form In theo dạng MDI Child
            frmInHoaDon fIn = new frmInHoaDon(printId);

            if (this.MdiParent != null)
            {
                fIn.MdiParent = this.MdiParent; // Mở trong form cha
                fIn.WindowState = FormWindowState.Maximized; // Phóng to để dễ xem báo cáo
                fIn.Show();
            }
            else
            {
                fIn.ShowDialog(); // Nếu không có form cha thì mở độc lập
            }
        }

        // ================= NÚT THOÁT =================
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================== XEM CHI TIẾT ==================
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dataGridView.Columns[e.ColumnIndex].Name == "XemChiTiet")
            {
                int detailId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells["ID"].Value);
                using (frmHoaDon_ChiTiet f = new frmHoaDon_ChiTiet(detailId))
                {
                    f.ShowDialog();
                }
                LoadData();
            }
        }
    }
}
