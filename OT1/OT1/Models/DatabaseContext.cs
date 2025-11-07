using Microsoft.EntityFrameworkCore;

namespace OT1.Models
{
    public class DatabaseContext:DbContext

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<LoaiSanPham> loaiSanPhams { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
    }
}
