using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class LoaiTaiKhoan
{
    public int Idloai { get; set; }

    public string? MaLoai { get; set; }

    public string? TenLoai { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
