using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OT1.Models
{
    [Table ( "SanPham")]
    public class SanPham
    {
        [Key]
        [DatabaseGenerated ( DatabaseGeneratedOption.Identity )]
        public long ID { get; set; }
        [Required]
        [Display(Name ="Mã Sản Phẩm")]
        [StringLength(10)]
        public string MaSanPham { get; set; }

        [Display (Name ="ten san pham")]
        public string TenSanPham { get;  set; }

        [Display (Name =" Hinh Anh")]
        public string HinhAnh {  get; set; }

        [Display (Name = "Soos luong")]
        public  int SoLuong     { get; set; }

        [Display (Name ="Don Gia")]
        public decimal DonGoa { get; set; }

        public long LoaiSanPhamID {  get; set; }
        public LoaiSanPham? LoaiSanPham { get;set; }

    }
}
