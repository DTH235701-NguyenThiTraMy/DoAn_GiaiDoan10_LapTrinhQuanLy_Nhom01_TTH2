using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTapHoa.Data
{
    public class HoaDon
    {
        public int ID { get; set; }
        public string MaHoaDon { get; set; } = string.Empty;   // HD20250322-001
        public int NhanVienID { get; set; }
        public int KhachHangID { get; set; }
        public DateTime NgayLap { get; set; }
        public string? GhiChu { get; set; }
        public int TongTien { get; set; }

        public virtual ObservableCollectionListSource<HoaDon_ChiTiet> HoaDon_ChiTiet { get; } = new();
        public virtual KhachHang KhachHang { get; set; } = null!;
        public virtual NhanVien NhanVien { get; set; } = null!;

        [NotMapped]
        public class DanhSachHoaDon
        {
            public int ID { get; set; }
            public string MaHoaDon { get; set; } = string.Empty;
            public string HoVaTenNhanVien { get; set; } = string.Empty;
            public string HoVaTenKhachHang { get; set; } = string.Empty;
            public DateTime NgayLap { get; set; }
            public int TongTienHoaDon { get; set; }
            public string XemChiTiet { get; set; } = "Xem chi tiết";
        }
    }
}
