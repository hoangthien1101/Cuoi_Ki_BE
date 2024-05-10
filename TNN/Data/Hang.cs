using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class Hang
{
    public int Idhang { get; set; }

    public string? TenHang { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
