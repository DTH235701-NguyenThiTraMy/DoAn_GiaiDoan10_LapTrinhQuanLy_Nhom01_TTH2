using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTapHoa.Data
{
    public class NhanVien
    {
        public int ID { get; set; }
        public string MaNhanVien { get; set; } = string.Empty;   // NV0001
        public string HoVaTen { get; set; } = string.Empty;
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public string TenDangNhap { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
        public bool QuyenHan { get; set; }

        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
    }
}
