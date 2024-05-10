using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class GioHang
{
    public int IdgioHang { get; set; }

    public int IdkhachHang { get; set; }

    public string? MaGioHang { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();

    public virtual User IdkhachHangNavigation { get; set; } = null!;
}
