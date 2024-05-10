using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class User
{
    public int Iduser { get; set; }

    public string? UserName { get; set; }

    public string? MatKhau { get; set; }

    public string? Ho { get; set; }

    public string? Ten { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? DiaChi { get; set; }

    /// <summary>
    /// 0:Nam 1:Nu
    /// </summary>
    public int? GioiTinh { get; set; }

    public DateTime? NgayTao { get; set; }

    public DateTime? NgaySua { get; set; }

    public int? Idloai { get; set; }

    public virtual ICollection<DonNhap> DonNhaps { get; set; } = new List<DonNhap>();

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual ICollection<HinhAnhUser> HinhAnhUsers { get; set; } = new List<HinhAnhUser>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual LoaiTaiKhoan? IdloaiNavigation { get; set; }
}
