using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class TinhTrangSp
{
    public int IdsanPham { get; set; }

    /// <summary>
    /// 0: Cũ 1: Mới
    /// </summary>
    public string TinhTrang { get; set; } = null!;

    public virtual SanPham IdsanPhamNavigation { get; set; } = null!;
}
