using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class ChiTietDonNhap
{
    public int IdchiTietDonNhap { get; set; }

    public int? IdsanPham { get; set; }

    public int? SoLuong { get; set; }

    public double? DonGia { get; set; }

    public double? ThanhTien { get; set; }

    public int? IddonNhap { get; set; }

    public virtual DonNhap? IddonNhapNavigation { get; set; }

    public virtual SanPham? IdsanPhamNavigation { get; set; }
}
