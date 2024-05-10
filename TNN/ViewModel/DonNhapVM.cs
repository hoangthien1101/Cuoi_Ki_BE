using System.Collections.Generic;
using System;
using TNN.Data;

namespace TNN.ViewModel
{
    public class DonNhapVM
    {


        public int? IdnhaCungCap { get; set; }

        public DateTime? NgayNhap { get; set; }

        public double? TongTien { get; set; }

        public int? Iduser { get; set; }
        public virtual NhaCungCap? IdnhaCungCapNavigation { get; set; }

        public virtual User? IduserNavigation { get; set; }
    }
    public class DonNhapMD : DonNhapVM
    {
        public int IddonNhap { get; set; }

        public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();
    }


    public class AddDonNhap
    {
        public int? IdnhaCungCap { get; set; }

        public DateTime? NgayNhap { get; set; }

        public double? TongTien { get; set; }

        public int? Iduser { get; set; }

    }

    public class EditDonNhap
    {
        public int? IdnhaCungCap { get; set; }

        public DateTime? NgayNhap { get; set; }

        public double? TongTien { get; set; }

        public int? Iduser { get; set; }

    }
}

