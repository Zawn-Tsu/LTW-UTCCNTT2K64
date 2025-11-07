using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kt1.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(50)]
        public string MaHoaDon { get; set; }

        [MaxLength(50)]
        public string MaKhachHang { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public DateTime? NgayNhan { get; set; }
        [MaxLength (300)]
        public string? HoTenKhachHang { get; set; }
        [MaxLength(300)]
        public string? Email { get; set; }
        [MaxLength(50)]
        public string? DienThoai { get; set; }
        [MaxLength(300)]
        public string? DiaChi { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TongTriGia { get; set; }
        public bool? TrangThai { get; set; }

        public int? KhachHangID { get; set; }
        // Navigation property
        public KhachHang? KhachHang { get; set; }
        
        public ICollection<CtHoaDon>? CtHoaDons { get; set; } = new HashSet<CtHoaDon>();
    }
}
