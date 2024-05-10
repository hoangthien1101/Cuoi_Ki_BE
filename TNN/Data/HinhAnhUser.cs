using System;
using System.Collections.Generic;

namespace TNN.Data;

public partial class HinhAnhUser
{
    public int IdhinhAnh { get; set; }

    public int? Iduser { get; set; }

    public string? UrlHinhAnh { get; set; }

    public bool IsAvt { get; set; }

    public virtual User? IduserNavigation { get; set; }
}
