using System;
using System.Linq;
using QuanLyCuaHangTapHoa.Data;

namespace QuanLyCuaHangTapHoa.Data
{
    public class MaTuDong
    {
        // ================= KHÁCH HÀNG =================
        public static string SinhMaKhachHang()
        {
            using (var db = new QLTHDbContext())
            {
                var last = db.KhachHang
                    .AsEnumerable()
                    .OrderByDescending(k => LaySo(k.MaKhachHang, "KH"))
                    .FirstOrDefault();

                int next = (last == null) ? 1 : LaySo(last.MaKhachHang, "KH") + 1;

                return "KH" + next.ToString("D4");
            }
        }

        // ================= NHÂN VIÊN =================
        public static string SinhMaNhanVien()
        {
            using (var db = new QLTHDbContext())
            {
                var last = db.NhanVien
                    .AsEnumerable()
                    .OrderByDescending(n => LaySo(n.MaNhanVien, "NV"))
                    .FirstOrDefault();

                int next = (last == null) ? 1 : LaySo(last.MaNhanVien, "NV") + 1;

                return "NV" + next.ToString("D4");
            }
        }

        // ================= SẢN PHẨM =================
        public static string SinhMaSanPham()
        {
            using (var db = new QLTHDbContext())
            {
                var last = db.SanPham
                    .AsEnumerable()
                    .OrderByDescending(s => LaySo(s.MaSanPham, "SP"))
                    .FirstOrDefault();

                int next = (last == null) ? 1 : LaySo(last.MaSanPham, "SP") + 1;

                return "SP" + next.ToString("D4");
            }
        }

        // ================= HÓA ĐƠN =================
        public static string SinhMaHoaDon()
        {
            using (var db = new QLTHDbContext())
            {
                string ngay = DateTime.Now.ToString("yyyyMMdd");

                var last = db.HoaDon
                    .Where(h => h.MaHoaDon.StartsWith("HD" + ngay))
                    .AsEnumerable()
                    .OrderByDescending(h => LaySoSauDauGach(h.MaHoaDon))
                    .FirstOrDefault();

                int next = (last == null) ? 1 : LaySoSauDauGach(last.MaHoaDon) + 1;

                return $"HD{ngay}-{next.ToString("D3")}";
            }
        }

        // ================= PHIẾU NHẬP =================
        public static string SinhMaPhieuNhap()
        {
            using (var db = new QLTHDbContext())
            {
                string ngay = DateTime.Now.ToString("yyyyMMdd");

                var last = db.PhieuNhap
                    .Where(p => p.MaPhieuNhap.StartsWith("PN" + ngay))
                    .AsEnumerable()
                    .OrderByDescending(p => LaySoSauDauGach(p.MaPhieuNhap))
                    .FirstOrDefault();

                int next = (last == null) ? 1 : LaySoSauDauGach(last.MaPhieuNhap) + 1;

                return $"PN{ngay}-{next.ToString("D3")}";
            }
        }

        // ================= HÀM DÙNG CHUNG =================

        // Lấy số phía sau prefix (KH0001 → 1)
        private static int LaySo(string ma, string prefix)
        {
            if (string.IsNullOrEmpty(ma) || !ma.StartsWith(prefix))
                return 0;

            string so = ma.Substring(prefix.Length);

            return int.TryParse(so, out int number) ? number : 0;
        }

        // Lấy số sau dấu "-" (HD20250322-001 → 1)
        private static int LaySoSauDauGach(string ma)
        {
            if (string.IsNullOrEmpty(ma)) return 0;

            var parts = ma.Split('-');
            if (parts.Length < 2) return 0;

            return int.TryParse(parts[1], out int number) ? number : 0;
        }
    }
}