using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangTapHoa.Data
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string MaKhachHang { get; set; } = string.Empty;   // KH0001
        public string HoVaTen { get; set; } = string.Empty;
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }

        public virtual ObservableCollectionListSource<HoaDon> HoaDon { get; } = new();
    }
}
