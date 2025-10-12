using System;
using System.Collections.Generic;

namespace Day0_Lab_DBF.Models;

public partial class TblChatlieu
{
    public string MaChatLieu { get; set; } = null!;

    public string TenChatLieu { get; set; } = null!;

    public virtual ICollection<TblHang> TblHangs { get; set; } = new List<TblHang>();
}
