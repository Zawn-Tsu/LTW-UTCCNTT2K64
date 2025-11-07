using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kt1.Models
{
    [Table("QuanTri")]
    public class QuanTri
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(100)]
        public string TenDangNhap { get; set; }

        [Required, MaxLength(200)]

        public string MatKhau { get; set; }

        public bool? TrangThai { get; set; }

    }
}
