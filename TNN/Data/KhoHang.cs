using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class KhoHang
{
    public int IdsanPham { get; set; }

    public int SltrongKho { get; set; }

    public virtual SanPham IdsanPhamNavigation { get; set; } = null!;
}
