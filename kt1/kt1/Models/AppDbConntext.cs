using Microsoft.EntityFrameworkCore;

namespace kt1.Models
{
    public class AppDbConntext:DbContext
    {
        public AppDbConntext(DbContextOptions<AppDbConntext> options) : base(options)
        {
        }
        public DbSet<QuanTri> QuanTris { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<CtHoaDon> CtHoaDons { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
    }
}
