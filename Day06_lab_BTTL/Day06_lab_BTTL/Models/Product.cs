using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day06_lab_BTTL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm bắt buộc nhập")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên sản phẩm phải từ 6 đến 150 ký tự")]
        public string Name { get; set; }

        [Display(Name = "Giá chuẩn")]
        [Required(ErrorMessage = "Giá chuẩn bắt buộc nhập")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá chuẩn phải ≥ 100000")]
        public float Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [Required(ErrorMessage = "Giá khuyến mãi bắt buộc nhập")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi không được âm")]
        public float SalePrice { get; set; }

        [Display(Name = "Ảnh sản phẩm")]
        public string Image { get; set; }

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Phải chọn danh mục")]
        public int CategoryId { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(1500, ErrorMessage = "Mô tả tối đa 1500 ký tự")]
        public string Description { get; set; }
    }
   
}
