using Day0_Codefirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Day0_Codefirst.entities
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<QuanTri> QuanTri { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<CTHoaDon> CTHoaDon { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPham { get; set; }
    }
}
