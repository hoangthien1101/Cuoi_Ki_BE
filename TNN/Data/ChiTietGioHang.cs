using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class ChiTietGioHang
{
    public int IdchiTietGioHang { get; set; }

    public int IdgioHang { get; set; }

    public int IdsanPham { get; set; }

    public int? SoLuong { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual GioHang IdgioHangNavigation { get; set; } = null!;

    public virtual SanPham IdsanPhamNavigation { get; set; } = null!;
}
