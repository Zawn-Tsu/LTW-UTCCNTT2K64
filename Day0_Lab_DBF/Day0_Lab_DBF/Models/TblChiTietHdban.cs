using System;
using System.Collections.Generic;

namespace Day0_Lab_DBF.Models;

public partial class TblChiTietHdban
{
    public string MaHdban { get; set; } = null!;

    public string MaHang { get; set; } = null!;

    public int? SoLuong { get; set; }

    public decimal? GiamGia { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual TblHang MaHangNavigation { get; set; } = null!;

    public virtual TblHdban MaHdbanNavigation { get; set; } = null!;
}
