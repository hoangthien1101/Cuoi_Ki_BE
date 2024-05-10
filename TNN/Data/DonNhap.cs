using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class DonNhap
{
    public int IddonNhap { get; set; }

    public int? IdnhaCungCap { get; set; }

    public DateTime? NgayNhap { get; set; }

    public double? TongTien { get; set; }

    public int? Iduser { get; set; }

    public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

    public virtual NhaCungCap? IdnhaCungCapNavigation { get; set; }

    public virtual User? IduserNavigation { get; set; }
}
