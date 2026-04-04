using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTapHoa.Data
{
    public class SanPham
    {
        public int ID { get; set; }                    // Khóa chính nội bộ (ẩn đi)
        public string MaSanPham { get; set; } = string.Empty;   // Mã hàng hóa đẹp (SP0001)
        public string TenSanPham { get; set; } = string.Empty;
        public int DonGiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string? HinhAnh { get; set; }
        public string? MoTa { get; set; }

        public virtual ObservableCollectionListSource<HoaDon_ChiTiet> HoaDon_ChiTiet { get; } = new();
        public virtual ObservableCollectionListSource<PhieuNhap_ChiTiet> PhieuNhap_ChiTiet { get; } = new();
    }
}
