using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kt1.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string MaKhachHang { get; set; }
        [Required, MaxLength(200)]
        public string TenKhachHang { get; set; }
        [MaxLength(200)]
        public string? Email { get; set; }
        [MaxLength(200)]
        public string? MatKhau { get; set; }
        [MaxLength(50)]
         public string? SoDienThoai { get; set; }
        [MaxLength(300)]
        public string? DiaChi { get; set; }
        public DateTime? NgayDangKy { get; set; }
        public bool? TrangThai { get; set; }
        public ICollection<HoaDon>? HoaDons { get; set; } 
    }
}
