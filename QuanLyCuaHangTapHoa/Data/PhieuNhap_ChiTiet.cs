using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTapHoa.Data
{
    public class PhieuNhap_ChiTiet
    {
        public int ID { get; set; }
        public int PhieuNhapID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuongNhap { get; set; }
        public int DonGiaNhap { get; set; }
        [ForeignKey("PhieuNhapID")]
        public virtual PhieuNhap PhieuNhap { get; set; } = null!;
        [ForeignKey("SanPhamID")]
        public virtual SanPham SanPham { get; set; } = null!;
    }
    [NotMapped]
    public class ChiTietPN
    {
        public int SanPhamID { get; set; }
        public string TenSanPham { get; set; } = string.Empty;
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
    }
}
