using Microsoft.Reporting.WinForms;
using QuanLyCuaHangTapHoa.Data;
using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace QuanLyCuaHangTapHoa.Reports
{
    public partial class frmThongKeDoanhThu : Form
    {
        QLTHDbContext db = new QLTHDbContext();

        QLTHDataSet.DoanhThuDataTable table =
            new QLTHDataSet.DoanhThuDataTable();

        string reportsFolder = Application.StartupPath
            .Replace("bin\\Debug\\net8.0-windows", "Reports");
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        // ================= LOAD =================
        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            var data = db.HoaDon
                .Select(h => new
                {
                    h.NgayLap,
                    TongTien = h.HoaDon_ChiTiet
                        .Sum(ct => ct.SoLuongBan * ct.DonGiaBan)
                })
                .ToList()
                .GroupBy(x => x.NgayLap.Date)
                .Select(g => new
                {
                    NgayLap = g.Key,
                    TongTien = g.Sum(x => x.TongTien),
                    SoHoaDon = g.Count()
                })
                .OrderBy(x => x.NgayLap)
                .ToList();

            table.Clear();

            foreach (var item in data)
            {
                table.AddDoanhThuRow(
                    item.NgayLap,
                    item.TongTien,
                    item.SoHoaDon
                );
            }

            ReportDataSource rds = new ReportDataSource
            {
                Name = "DoanhThu",
                Value = table
            };

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);

            reportViewer.LocalReport.ReportPath =
                Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");

            ReportParameter rp = new ReportParameter(
                "MoTaKetQuaHienThi",
                "(Tất cả thời gian)"
            );

            reportViewer.LocalReport.SetParameters(rp);

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;

            reportViewer.RefreshReport();
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show("Từ ngày không được lớn hơn đến ngày!");
                return;
            }

            var data = db.HoaDon
                .Where(h => h.NgayLap.Date >= tuNgay &&
                            h.NgayLap.Date <= denNgay)
                .Select(h => new
                {
                    h.NgayLap,
                    TongTien = h.HoaDon_ChiTiet
                        .Sum(ct => ct.SoLuongBan * ct.DonGiaBan)
                })
                .ToList()
                .GroupBy(x => x.NgayLap.Date)
                .Select(g => new
                {
                    NgayLap = g.Key,
                    TongTien = g.Sum(x => x.TongTien),
                    SoHoaDon = g.Count()
                })
                .OrderBy(x => x.NgayLap)
                .ToList();

            table.Clear();

            foreach (var item in data)
            {
                table.AddDoanhThuRow(
                    item.NgayLap,
                    item.TongTien,
                    item.SoHoaDon
                );
            }

            ReportDataSource rds = new ReportDataSource
            {
                Name = "DoanhThu",
                Value = table
            };

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(rds);

            reportViewer.LocalReport.ReportPath =
                Path.Combine(reportsFolder, "rptThongKeDoanhThu.rdlc");

            ReportParameter rp = new ReportParameter(
                "MoTaKetQuaHienThi",
                "Từ ngày " + dtpTuNgay.Text + " - Đến ngày: " + dtpDenNgay.Text
            );

            reportViewer.LocalReport.SetParameters(rp);

            reportViewer.RefreshReport();
        }

        private void btnTatCa_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
