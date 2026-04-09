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

        private int id;

        // Thư mục Reports giờ sẽ nằm cùng thư mục chạy app (nhớ set Copy if newer cho file .rdlc)
        private string reportsFolder = Path.Combine(Application.StartupPath, "Reports");
        public frmInHoaDon(int maHoaDon = 0)
        {
            InitializeComponent();
            id = maHoaDon;
        }
        private void frmInHoaDon_Load(object sender, EventArgs e)
        {
            try
            {                
                using (var db = new QLTHDbContext())
                {
                    var hoaDon = db.HoaDon
                        .Include(r => r.KhachHang)
                        .Include(r => r.HoaDon_ChiTiet)
                            .ThenInclude(chiTiet => chiTiet.SanPham)
                        .FirstOrDefault(r => r.ID == id);

                    if (hoaDon != null)
                    {
                        QLTHDataSet.HoaDon_ChiTietDataTable danhSachTable = new QLTHDataSet.HoaDon_ChiTietDataTable();
                        
                        foreach (var r in hoaDon.HoaDon_ChiTiet)
                        {
                            danhSachTable.AddHoaDon_ChiTietRow(
                                r.ID,
                                r.HoaDonID,
                                r.SanPhamID,
                                r.SanPham.TenSanPham,
                                r.SoLuongBan,
                                r.DonGiaBan,
                                r.SoLuongBan * r.DonGiaBan,
                                r.SanPham.MaSanPham,
                                r.HoaDon.MaHoaDon
                            );
                        }

                        ReportDataSource rds = new ReportDataSource
                        {
                            Name = "HoaDon_ChiTiet",
                            Value = danhSachTable
                        };

                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(rds);

                        // Gắn đường dẫn file
                        string reportPath = Path.Combine(reportsFolder, "rptInHoaDon.rdlc");
                        if (!File.Exists(reportPath))
                        {
                            MessageBox.Show("Không tìm thấy mẫu in hóa đơn tại: " + reportPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        reportViewer1.LocalReport.ReportPath = reportPath;

                        // Tinh chỉnh Parameters: Xử lý an toàn trường hợp không có khách hàng (khách lẻ)
                        string tenKhach = hoaDon.KhachHang?.HoVaTen ?? "Khách lẻ";
                        string diaChiKhach = hoaDon.KhachHang?.DiaChi ?? "";
                        double tongTien = hoaDon.HoaDon_ChiTiet.Sum(r => r.SoLuongBan * r.DonGiaBan);
                        string tienBangChu = ChuyenSoSangChu(tongTien);

                        IList<ReportParameter> param = new List<ReportParameter>
                        {
                            new ReportParameter("NgayLap", $"Ngày {hoaDon.NgayLap:dd} tháng {hoaDon.NgayLap:MM} năm {hoaDon.NgayLap:yyyy}"), // Định dạng ngày tháng gọn hơn
                            new ReportParameter("NguoiBan_Ten", "T-Market"), // Gợi ý: Lấy từ DB nếu có
                            new ReportParameter("NguoiBan_DiaChi", "Mỹ Phước, TP. Long Xuyên, An Giang"),
                            new ReportParameter("NguoiBan_MaSoThue", "1602162070"),
                            new ReportParameter("NguoiMua_Ten", tenKhach),
                            new ReportParameter("NguoiMua_DiaChi", diaChiKhach),
                            new ReportParameter("NguoiMua_MaSoThue", ""),
                            new ReportParameter("pSoTienBangChu", tienBangChu)
                        };

                        reportViewer1.LocalReport.SetParameters(param);

                        reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                        reportViewer1.ZoomMode = ZoomMode.Percent;
                        reportViewer1.ZoomPercent = 100;

                        reportViewer1.RefreshReport();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin hóa đơn này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi tải hóa đơn: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string ChuyenSoSangChu(double total)
        {
            try
            {
                string[] unitNumbers = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
                string[] placeValues = { "", "nghìn", "triệu", "tỷ", "nghìn tỷ", "triệu tỷ" };

                bool isNegative = false;
                if (total < 0)
                {
                    isNegative = true;
                    total = Math.Abs(total);
                }

                if (total == 0) return "Không đồng";

                string result = "";
                long temp = (long)total;
                int placeValueIndex = 0;

                while (temp > 0)
                {
                    int threeDigits = (int)(temp % 1000);
                    temp /= 1000;

                    if (threeDigits > 0)
                    {
                        string part = ReadThreeDigits(threeDigits, temp > 0);
                        result = part + " " + placeValues[placeValueIndex] + " " + result;
                    }
                    placeValueIndex++;
                }

                result = result.Trim();
                if (isNegative) result = "Âm " + result;

                // Viết hoa chữ cái đầu và thêm "đồng"
                return char.ToUpper(result[0]) + result.Substring(1) + " đồng.";
            }
            catch { return ""; }
        }

        private static string ReadThreeDigits(int number, bool hasHigherPart)
        {
            string[] unitNumbers = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            int hundreds = number / 100;
            int tens = (number % 100) / 10;
            int units = number % 10;
            string res = "";

            if (hundreds > 0 || hasHigherPart) res += unitNumbers[hundreds] + " trăm ";

            if (tens > 1)
            {
                res += unitNumbers[tens] + " mươi ";
                if (units == 1) res += "mốt";
                else if (units == 5) res += "lăm";
                else if (units > 0) res += unitNumbers[units];
            }
            else if (tens == 1)
            {
                res += "mười ";
                if (units == 5) res += "lăm";
                else if (units > 0) res += unitNumbers[units];
            }
            else if (units > 0)
            {
                if (hundreds > 0 || hasHigherPart) res += "lẻ " + unitNumbers[units];
                else res += unitNumbers[units];
            }

            return res.Trim();
        }
    }
}