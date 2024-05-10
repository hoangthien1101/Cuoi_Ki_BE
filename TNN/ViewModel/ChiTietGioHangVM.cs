using TNN.Data;

namespace TNN.ViewModel
{
    public class ChiTietGioHangVM
    {
        public int IdgioHang { get; set; }

        public int IdsanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? ThanhTien { get; set; }
    }
    public class ChiTietGioHangMD : ChiTietGioHangVM
    {
        public int IdchiTietGioHang { get; set; }

        public virtual GioHang IdgioHangNavigation { get; set; } = null!;

        public virtual SanPham IdsanPhamNavigation { get; set; } = null!;
    }

    public class AddChiTietGioHang
    {
        public int IdgioHang { get; set; }

        public int IdsanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? ThanhTien { get; set; }
    }

    public class editChiTietGioHang
    {

        public int IdsanPham { get; set; }

        public int? SoLuong { get; set; }

        public decimal? ThanhTien { get; set; }
    }
}
