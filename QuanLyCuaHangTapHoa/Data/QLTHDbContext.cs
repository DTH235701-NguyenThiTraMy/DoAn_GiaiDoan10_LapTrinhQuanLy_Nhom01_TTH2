using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace QuanLyCuaHangTapHoa.Data
{
    public class QLTHDbContext: DbContext
    {
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<HoaDon_ChiTiet> HoaDon_ChiTiet { get; set; }
        public DbSet<PhieuNhap> PhieuNhap { get; set; }
        public DbSet<PhieuNhap_ChiTiet> PhieuNhap_ChiTiet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["QLTapHoaConnection"].ConnectionString);
        }
    }
}
