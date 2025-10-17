using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09CF.Models
{
    [Table ("nvtLoai_SanPham")]
    [Index(nameof(nvtMaLoai), IsUnique = true)]
    public class nvtLoai_SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nvtId { get; set; }

        [Display(Name = "Mã loại")]
        [StringLength(10)]
        public string nvtMaLoai { get; set; }

        [Display(Name = "Tên loại")]
        [StringLength(50)]
        public string nvtTenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool nvtTrangThai { get; set; }

        public ICollection<nvtSan_Pham> nvtSan_Phams { get; set; } = new HashSet<nvtSan_Pham>();
    }
}
