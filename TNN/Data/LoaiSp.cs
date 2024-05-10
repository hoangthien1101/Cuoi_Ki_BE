using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class LoaiSp
{
    public int IdloaiSp { get; set; }

    public string? MaLoaiSp { get; set; }

    public string? TenLoaiSp { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
