using Microsoft.Reporting.WinForms;
using QuanLyCuaHangTapHoa.Data;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using static QuanLyCuaHangTapHoa.Reports.QLTHDataSet;

namespace QuanLyCuaHangTapHoa.Reports
{
    public partial class frmThongKeSanPham : Form
    {
        // Khởi tạo các biến toàn cục (chỉ giữ lại những biến cần thiết)
        private string reportsFolder = Path.Combine(Application.StartupPath, "Reports");

        public frmThongKeSanPham()
        {
            InitializeComponent();
        }

        // ================= LOAD FORM =================
        private void frmThongKeSanPham_Load(object sender, EventArgs e)
        {
            cboLoc.SelectedIndex = 0;
            cboSapXep.SelectedIndex = 0;

            // Thiết lập giá trị mặc định cho DateTimePicker (Ví dụ: Lọc từ đầu tháng đến hiện tại)
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;

            LoadReport();
        }

        // ================= LOAD REPORT =================
        private void LoadReport()
        {
            try
            {
                using (var db = new QLTHDbContext())
                {
                    // Lấy khoảng thời gian từ UI, chuẩn hóa giờ để lấy trọn vẹn ngày
                    DateTime tuNgay = dtpTuNgay.Value.Date; // Lấy mốc 00:00:00 của ngày bắt đầu
                    DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1); // Lấy mốc 23:59:59 của ngày kết thúc

                    // 1. TRUY VẤN KẾT HỢP VÀ TÍNH TỔNG BÁN THEO NGÀY
                    var rawQuery = db.SanPham.Select(s => new
                    {
                        s.ID,
                        s.MaSanPham,
                        s.TenSanPham,
                        s.DonGiaBan,
                        s.SoLuongTon,
                        // Tính tổng số lượng đã bán CHỈ TRONG khoảng thời gian đã chọn
                        TongBan = db.HoaDon_ChiTiet
                                    .Where(ct => ct.SanPhamID == s.ID &&
                                                 ct.HoaDon.NgayLap >= tuNgay &&
                                                 ct.HoaDon.NgayLap <= denNgay)
                                    .Sum(ct => (int?)ct.SoLuongBan) ?? 0
                    });

                    // 2. XỬ LÝ TÌM KIẾM THEO UI
                    string tuKhoa = txtTuKhoa.Text.Trim();
                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        rawQuery = rawQuery.Where(s => s.TenSanPham.Contains(tuKhoa) || s.MaSanPham.Contains(tuKhoa));
                    }

                    // 3. XỬ LÝ LỌC
                    int locIndex = cboLoc.SelectedIndex;
                    if (locIndex == 1) rawQuery = rawQuery.Where(s => s.SoLuongTon < 10);
                    else if (locIndex == 2) rawQuery = rawQuery.Where(s => s.SoLuongTon > 50);

                    // 4. XỬ LÝ SẮP XẾP
                    switch (cboSapXep.SelectedIndex)
                    {
                        case 1: rawQuery = rawQuery.OrderBy(s => s.DonGiaBan); break;
                        case 2: rawQuery = rawQuery.OrderByDescending(s => s.DonGiaBan); break;
                        case 3: rawQuery = rawQuery.OrderBy(s => s.SoLuongTon); break;
                        case 4: rawQuery = rawQuery.OrderByDescending(s => s.SoLuongTon); break;
                        case 5: rawQuery = rawQuery.OrderByDescending(s => s.TongBan); break; // Sắp xếp bán chạy nhất lên đầu
                    }

                    var resultList = rawQuery.ToList();

                    // 5. ĐỔ DỮ LIỆU VÀO DATASET
                    QLTHDataSet.DanhSachSanPhamDataTable table = new QLTHDataSet.DanhSachSanPhamDataTable();

                    foreach (var item in resultList)
                    {
                        // Logic phân loại sức bán
                        string danhGia = "Bình thường";
                        if (item.TongBan >= 50) danhGia = "Bán chạy";
                        else if (item.TongBan == 0) danhGia = "Chưa bán được";
                        else if (item.TongBan < 10) danhGia = "Bán chậm";

                        table.AddDanhSachSanPhamRow(
                            item.ID,
                            item.MaSanPham,
                            item.TenSanPham,
                            item.DonGiaBan,
                            item.SoLuongTon,
                            item.TongBan,
                            danhGia
                        );
                    }

                    // 6. HIỂN THỊ LÊN REPORT VIEWER (Truyền thêm 2 biến tuNgay, denNgay vào hàm)
                    UpdateReportUI(table, resultList.Count, tuNgay, denNgay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xử lý báo cáo: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= CẬP NHẬT GIAO DIỆN BÁO CÁO =================
        private void UpdateReportUI(QLTHDataSet.DanhSachSanPhamDataTable table, int count, DateTime tuNgay, DateTime denNgay)
        {
            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DanhSachSanPham", (System.Data.DataTable)table));

            string reportPath = Path.Combine(reportsFolder, "rptThongKeSanPham.rdlc");
            if (!File.Exists(reportPath))
            {
                MessageBox.Show("Không tìm thấy file rptThongKeSanPham.rdlc tại: " + reportPath);
                return;
            }

            reportViewer.LocalReport.ReportPath = reportPath;

            // --- THÊM PARAMETER NGÀY THÁNG VÀO BÁO CÁO ---
            ReportParameter[] paramsArray = new ReportParameter[] {
                new ReportParameter("pTuNgay", tuNgay.ToString("dd/MM/yyyy")),
                new ReportParameter("pDenNgay", denNgay.ToString("dd/MM/yyyy"))
            };
            reportViewer.LocalReport.SetParameters(paramsArray);
            // ---------------------------------------------

            // Thông báo kết quả trên Form
            if (count == 0)
            {
                lblThongBao.Text = "Không tìm thấy dữ liệu phù hợp!";
                lblThongBao.ForeColor = Color.Red;
            }
            else
            {
                lblThongBao.Text = $"Đã tìm thấy {count} mặt hàng.";
                lblThongBao.ForeColor = Color.DarkGreen;
            }

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        // ================= SỰ KIỆN NÚT BẤM & GIAO DIỆN =================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();
            cboLoc.SelectedIndex = 0;
            cboSapXep.SelectedIndex = 0;
            // Reset ngày về tháng hiện tại
            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Now;
            lblThongBao.Text = "";

            LoadReport();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e) => LoadReport();
        private void btnLoc_Click(object sender, EventArgs e) => LoadReport();
        private void btnSapXep_Click(object sender, EventArgs e) => LoadReport();

        // Tùy chọn: Tự động load lại báo cáo khi người dùng thay đổi ngày
        private void dtpTuNgay_ValueChanged(object sender, EventArgs e) => LoadReport();
        private void dtpDenNgay_ValueChanged(object sender, EventArgs e) => LoadReport();

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            // Tùy chọn: Tìm kiếm live khi gõ (nếu data không quá lớn)
            // LoadReport(); 
        }
    }
}