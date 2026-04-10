using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyCuaHangTapHoa.Data;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangTapHoa.Reports
{
    public partial class frmThongKeDoanhThu : Form
    {
        private readonly QLTHDbContext _context = new QLTHDbContext();
        private readonly QLTHDataSet.DoanhThuDataTable _dataTable = new QLTHDataSet.DoanhThuDataTable();

        private readonly string _reportPath;

        public frmThongKeDoanhThu()
        {
            InitializeComponent();

            _reportPath = Path.Combine(Application.StartupPath, "Reports", "rptThongKeDoanhThu.rdlc");
            
            if (!File.Exists(_reportPath) && Application.StartupPath.Contains(@"\bin\"))
            {
                _reportPath = Path.Combine(
                    Application.StartupPath.Replace(@"\bin\Debug\net8.0-windows", ""),
                    "Reports",
                    "rptThongKeDoanhThu.rdlc");
            }
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {            
            if (cboLocNhanh.Items.Count > 0)
                cboLocNhanh.SelectedIndex = 0;

            LoadReportData(null, null);
        }

        private void LoadReportData(DateTime? tuNgay, DateTime? denNgay)
        {
            try
            {
                var query = _context.HoaDon
                    .AsNoTracking()
                    .AsQueryable();

                if (tuNgay.HasValue && denNgay.HasValue)
                {
                    query = query.Where(h => h.NgayLap.Date >= tuNgay.Value.Date &&
                                             h.NgayLap.Date <= denNgay.Value.Date);
                }

                var rawData = query
                    .Select(h => new
                    {
                        Ngay = h.NgayLap.Date,
                        TongTien = h.HoaDon_ChiTiet.Sum(ct => (decimal?)ct.SoLuongBan * ct.DonGiaBan) ?? 0m
                    })
                    .ToList();

                var data = rawData
                    .GroupBy(x => x.Ngay)
                    .Select(g => new
                    {
                        NgayLap = g.Key,
                        DoanhThu = g.Sum(x => x.TongTien),
                        SoHoaDon = g.Count()
                    })
                    .OrderBy(x => x.NgayLap)
                    .ToList();

                // Cập nhật Dashboard (Label)
                decimal tongDoanhThu = data.Sum(x => x.DoanhThu);
                int tongDonHang = data.Sum(x => x.SoHoaDon);

                lblTongDoanhThu.Text = $"{tongDoanhThu:N0} VNĐ";
                lblTongDonHang.Text = $"{tongDonHang:N0}";

                // Đổ dữ liệu vào DataTable cho Report
                _dataTable.Clear();
                foreach (var item in data)
                {
                    _dataTable.AddDoanhThuRow(
                        item.NgayLap,
                        (long)item.DoanhThu,      
                        item.SoHoaDon
                    );
                }

                // Cấu hình ReportViewer
                reportViewer.LocalReport.DataSources.Clear();

                
                reportViewer.LocalReport.DataSources.Add(
                    new ReportDataSource("DoanhThu", (DataTable)_dataTable)
                );

                if (File.Exists(_reportPath))
                {
                    reportViewer.LocalReport.ReportPath = _reportPath;
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy file báo cáo:\n{_reportPath}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Truyền tham số cho báo cáo
                string moTa = tuNgay.HasValue
                    ? $"Từ ngày {tuNgay.Value:dd/MM/yyyy} đến {denNgay.Value:dd/MM/yyyy}"
                    : "Tất cả các kỳ báo cáo";

                reportViewer.LocalReport.SetParameters(
                    new ReportParameter("MoTaKetQuaHienThi", moTa)
                );

                // Thiết lập giao diện báo cáo
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo:\n" + ex.Message,
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================== CÁC NÚT CHỨC NĂNG ======================

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadReportData(dtpTuNgay.Value, dtpDenNgay.Value);
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            // Bỏ chọn ComboBox lọc nhanh
            cboLocNhanh.SelectedIndex = -1;
            LoadReportData(null, null);
        }

        private void cboLocNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;

            switch (cboLocNhanh.SelectedIndex)
            {
                case 1: // Hôm nay
                    dtpTuNgay.Value = dtpDenNgay.Value = today;
                    LoadReportData(today, today);
                    break;

                case 2: // Tháng này
                    dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
                    dtpDenNgay.Value = today;
                    LoadReportData(dtpTuNgay.Value, dtpDenNgay.Value);
                    break;

                case 3: // Tất cả
                    btnTatCa_Click(null, null);
                    break;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Giải phóng tài nguyên
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _context?.Dispose();
            base.OnFormClosing(e);
        }
    }
}