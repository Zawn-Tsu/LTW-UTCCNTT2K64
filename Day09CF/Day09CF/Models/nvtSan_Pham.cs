using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day09CF.Models
{
    [Table("nvtSan_Pham")]
    public class nvtSan_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long nvtId { get; set; }

        [Display(Name = "Mã sản phẩm")]
        [Required]
        [StringLength(10)]
        public string nvtMaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string nvtTenSanPham { get; set; }

        [Display(Name = "Hình ảnh")]
        public string nvtHinhAnh { get; set; }

        [Display(Name = "Số lượng")]
        public int nvtSoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal nvtDonGia { get; set; }


        public long nvtLoaiSanPhamId { get; set; }
        [ForeignKey("nvtLoaiSanPhamId")]
        public nvtLoai_SanPham? nvtLoai_SanPham { get; set; }
    }
}
