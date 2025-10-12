using System;
using System.Collections.Generic;

namespace Day0_Lab_DBF.Models;

public partial class TblHang
{
    public string MaHang { get; set; } = null!;

    public string TenHang { get; set; } = null!;

    public string MaChatLieu { get; set; } = null!;

    public int? SoLuong { get; set; }

    public decimal? DonGiaNhap { get; set; }

    public decimal? DonGiaBan { get; set; }

    public string? Anh { get; set; }

    public string? GhiChu { get; set; }

    public virtual TblChatlieu MaChatLieuNavigation { get; set; } = null!;

    public virtual ICollection<TblChiTietHdban> TblChiTietHdbans { get; set; } = new List<TblChiTietHdban>();
}
