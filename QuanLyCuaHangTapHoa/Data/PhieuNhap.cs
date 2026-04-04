using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTapHoa.Data
{
    public class PhieuNhap
    {
        public int ID { get; set; }
        public string MaPhieuNhap { get; set; } = string.Empty;   // PN20250322-001
        public int NhanVienID { get; set; }
        public DateTime NgayNhap { get; set; }
        public string? GhiChu { get; set; }
        public int TongTien { get; set; }      


        public virtual ObservableCollectionListSource<PhieuNhap_ChiTiet> PhieuNhap_ChiTiet { get; } = new();
        [ForeignKey("NhanVienID")]
        public virtual NhanVien NhanVien { get; set; } = null!;
    }

    [NotMapped]
    public class DanhSachPhieuNhap
    {
        public int ID { get; set; }
        public string MaPhieuNhap { get; set; } = string.Empty;
        public string HoVaTenNhanVien { get; set; } = string.Empty;
        public DateTime NgayNhap { get; set; }
        public int TongTien { get; set; }
        public string XemChiTiet { get; set; } = "Xem chi tiết";
    }
}
