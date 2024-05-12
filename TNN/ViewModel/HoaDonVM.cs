using TNN.Data;

namespace TNN.ViewModel
{
    public class HoaDonVM
    {

        public int IddonHang { get; set; }

        public int? Iduser { get; set; }
        public string? MaDonHang { get; set; }

        public DateTime? NgayDatHang { get; set; }

        public decimal? TongTien { get; set; }

        public virtual User? IduserNavigation { get; set; }
    }

    public class HoaDonMD : HoaDonVM
    {
        public int IddonHang { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }

    public class AddHoaDon
    {
        public string? MaDonHang { get; set; }
        public int Iduser { get; set; }

        public DateTime? NgayDatHang { get; set; }

        public decimal? TongTien { get; set; }


    }

    //public class Edit
    //{
    //    public string? MaDonHang { get; set; }
    //    public int Iduser { get; set; }

    //    public DateTime? NgayDatHang { get; set; }

    //    public decimal? TongTien { get; set; }
    //}

}
