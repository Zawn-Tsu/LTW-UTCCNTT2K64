using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kt1.Models
{
    [Table("LoaiSanPham")]
    public class LoaiSanPham
    {
        [Key]
        public int ID { get; set; } 
        [ MaxLength(100)]  
        public string MaLoai { get; set; }
        [Required, MaxLength(200)]
        public string TenLoai { get; set; }
        public bool? TrangThai { get; set; }    
        public ICollection<SanPham>? SanPhams { get; set; } = new HashSet<SanPham>();
    }
}
