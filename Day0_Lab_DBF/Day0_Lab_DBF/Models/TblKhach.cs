﻿using System;
using System.Collections.Generic;

namespace Day0_Lab_DBF.Models;

public partial class TblKhach
{
    public string MaKhach { get; set; } = null!;

    public string TenKhach { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? DienThoai { get; set; }

    public virtual ICollection<TblHdban> TblHdbans { get; set; } = new List<TblHdban>();
}
