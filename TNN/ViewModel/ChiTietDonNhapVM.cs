using TNN.Data;

namespace TNN.ViewModel
{
    public class ChiTietDonNhapVM
    {

        public int? IdsanPham { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? ThanhTien { get; set; }

        public int? IddonNhap { get; set; }
        public virtual DonNhap? IddonNhapNavigation { get; set; }

        public virtual SanPham? IdsanPhamNavigation { get; set; }

    }
    public class ChiTietDonNhapMD : ChiTietDonNhapVM
    {
        public int IdchiTietDonNhap { get; set; }

    }

    public class addChiTietDonNhap
    {

        public int? IdsanPham { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? ThanhTien { get; set; }

        public int? IddonNhap { get; set; }
    }

    public class editChiTietDonNhap
    {

        public int? IdsanPham { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? ThanhTien { get; set; }

        public int? IddonNhap { get; set; }
    }
}
