using System.ComponentModel.DataAnnotations;

namespace Day12Lab_Th1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Email phải bắt buộc phải đc nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._%+-]+\.[A-Za-z]{2,4}")]             
        public string? Email { get; set; }
        [StringLength(100, MinimumLength =8)]
        [Required]
        public string? Password { get; set; }
        [Required]
        public Branch? Branch { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public bool IsRegular { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string? Address { get; set; }
        [Range(typeof(DateTime), "1963-01-01", "2005-12-31")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBorth { get; set; }
        public string? AvatarFileName { get; set; }

    }
}
