using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kt1.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string MaSanPham { get; set; }
        [Required, MaxLength(200)]
      
        public string TenSanPham { get; set; }
        [MaxLength(500)]
        public string? HinhAnh { get; set; }
        public int SoLuong { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Gia { get; set; }
       
      
        public bool? TrangThai { get; set; }
        // Foreign key
        public int? LoaiSanPhamID { get; set; }
        // Navigation property
        public LoaiSanPham? LoaiSanPham { get; set; }
        public ICollection<CtHoaDon>? CtHoaDons { get; set; } = new HashSet<CtHoaDon>();
    }
}
