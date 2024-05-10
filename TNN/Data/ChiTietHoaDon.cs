using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class ChiTietHoaDon
{
    public int IdchiTietDonHang { get; set; }

    public int IddonHang { get; set; }

    public int IdsanPham { get; set; }

    public int SoLuong { get; set; }

    public decimal ThanhTien { get; set; }

    public virtual HoaDon IddonHangNavigation { get; set; } = null!;

    public virtual SanPham IdsanPhamNavigation { get; set; } = null!;
}
