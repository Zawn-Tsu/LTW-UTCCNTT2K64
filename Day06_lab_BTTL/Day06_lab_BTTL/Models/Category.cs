using System.ComponentModel.DataAnnotations;

namespace Day06_lab_BTTL.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục bắt buộc nhập")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Tên danh mục từ 2 đến 150 ký tự")]
        public string Name { get; set; }

    }
}
