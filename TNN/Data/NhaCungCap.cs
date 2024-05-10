using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class NhaCungCap
{
    public int IdnhaCungCap { get; set; }

    public string TenNhaCungCap { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string SoDienThoai { get; set; } = null!;

    public virtual ICollection<DonNhap> DonNhaps { get; set; } = new List<DonNhap>();
}
