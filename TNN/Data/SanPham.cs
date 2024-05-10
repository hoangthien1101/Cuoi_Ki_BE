using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class SanPham
{
    public int IdsanPham { get; set; }

    public string MaSp { get; set; } = null!;

    public string TenSp { get; set; } = null!;

    public int IdloaiSp { get; set; }

    public int Idhang { get; set; }

    public decimal Gia { get; set; }

    public int NamSx { get; set; }

    public string CongSuat { get; set; } = null!;

    public string? GhiChu { get; set; }
    public string? TinhTrang { get; set; }
    public int? SoLuong { get; set; }

    public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

    public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; set; } = new List<ChiTietGioHang>();

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual Hang IdhangNavigation { get; set; } = null!;

    public virtual LoaiSp IdloaiSpNavigation { get; set; } = null!;
}
