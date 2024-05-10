using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class HoaDon
{
    public int IddonHang { get; set; }

    public int? Iduser { get; set; }

    public string? MaDonHang { get; set; }

    public DateTime? NgayDatHang { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual User? IduserNavigation { get; set; }
}
