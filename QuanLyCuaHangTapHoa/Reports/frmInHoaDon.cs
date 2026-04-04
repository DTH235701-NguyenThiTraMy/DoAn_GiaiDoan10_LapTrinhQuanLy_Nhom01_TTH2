using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using QuanLyCuaHangTapHoa.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCuaHangTapHoa.Reports
{
    public partial class frmInHoaDon : Form
    {
        QLTHDbContext db = new QLTHDbContext();

        QLTHDataSet.HoaDon_ChiTietDataTable danhSachHoaDon_ChiTietDataTable =
            new QLTHDataSet.HoaDon_ChiTietDataTable();

        string reportsFolder = Application.StartupPath
            .Replace("bin\\Debug\\net8.0-windows", "Reports");

        int id;
        public frmInHoaDon(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
        }
        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            var hoaDon = db.HoaDon
                .Include(r => r.KhachHang)
                .Include(r => r.HoaDon_ChiTiet)
                .FirstOrDefault(r => r.ID == id);

            if (hoaDon != null)
            {
                var hoaDonChiTiet = db.HoaDon_ChiTiet
                    .Include(r => r.SanPham)
                    .Where(r => r.HoaDonID == id)
                    .Select(r => new
                    {
                        r.ID,
                        r.HoaDonID,
                        r.SanPhamID,
                        TenSanPham = r.SanPham.TenSanPham,
                        r.SoLuongBan,
                        r.DonGiaBan,
                        ThanhTien = r.SoLuongBan * r.DonGiaBan
                    }).ToList();

                danhSachHoaDon_ChiTietDataTable.Clear();

                foreach (var row in hoaDonChiTiet)
                {
                    danhSachHoaDon_ChiTietDataTable.AddHoaDon_ChiTietRow(
                        row.ID,
                        row.HoaDonID,
                        row.SanPhamID,
                        row.TenSanPham,
                        row.SoLuongBan,
                        row.DonGiaBan,
                        row.ThanhTien
                    );
                }

                ReportDataSource rds = new ReportDataSource
                {
                    Name = "HoaDon_ChiTiet",
                    Value = danhSachHoaDon_ChiTietDataTable
                };

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                reportViewer1.LocalReport.ReportPath =
                    Path.Combine(reportsFolder, "rptInHoaDon.rdlc");

                IList<ReportParameter> param = new List<ReportParameter>
                {
                    new ReportParameter("NgayLap", $"Ngày {hoaDon.NgayLap.Day} Tháng {hoaDon.NgayLap.Month} Năm {hoaDon.NgayLap.Year}"),
                    new ReportParameter("NguoiBan_Ten", "T-Market"),
                    new ReportParameter("NguoiBan_DiaChi", "Mỹ Phước, TP. Long Xuyên, An Giang"),
                    new ReportParameter("NguoiBan_MaSoThue", "1602162070"),
                    new ReportParameter("NguoiMua_Ten", hoaDon.KhachHang.HoVaTen),
                    new ReportParameter("NguoiMua_DiaChi", hoaDon.KhachHang.DiaChi),
                    new ReportParameter("NguoiMua_MaSoThue", ""),
                    //new ReportParameter("TongTien",
                    //    hoaDon.HoaDon_ChiTiet
                    //    .Sum(r => r.SoLuongBan * r.DonGiaBan)
                    //    .ToString("#,##0"))
                };

                reportViewer1.LocalReport.SetParameters(param);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

                reportViewer1.RefreshReport();
            }
        }
    }
}
