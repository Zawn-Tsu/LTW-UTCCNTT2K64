using Microsoft.EntityFrameworkCore;

namespace Day09CF.Models
{
    public class Day09CFContext:DbContext
    {
        public Day09CFContext(DbContextOptions<Day09CFContext> options):base(options) { }
        public DbSet<nvtLoai_SanPham> nvtLoai_SanPhams { get; set; }
        public DbSet<nvtSan_Pham> nvtSan_Phams { get; set; }

    }
}
