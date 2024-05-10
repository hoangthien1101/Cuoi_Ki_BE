using TNN.Data;

namespace TNN.ViewModel
{
    public class GioHangVM
    {
        public int IdkhachHang { get; set; }

        public string? MaGioHang { get; set; }

        public decimal? TongTien { get; set; }
        
    }
    public class GioHangMD : GioHangVM
    {
        public int IdgioHang { get; set; }        
        public virtual ICollection<ChiTietGioHangVM> ChiTietGioHangs { get; set; } = new List<ChiTietGioHangVM>();
        public virtual User IdkhachHangNavigation { get; set; } = null!;
    }

    public class EditGioHang
    {
        public int IdkhachHang { get; set; }

        public string? MaGioHang { get; set; }

        public decimal? TongTien { get; set; }
    }

    public class AddGioHang
    {
        public int IdkhachHang { get; set; }

        public string? MaGioHang { get; set; }

        public decimal? TongTien { get; set; }
            
    }
}

