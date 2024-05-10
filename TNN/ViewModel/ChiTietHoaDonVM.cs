using TNN.Data;

namespace TNN.ViewModel
{
    public class ChiTietHoaDonVM
    {


        public int IdsanPham { get; set; }

        public int IddonHang { get; set; }

        public int SoLuong { get; set; }

        public decimal ThanhTien { get; set; }

    }


    public class ChiTietHoaDonMD
    {
        public int IdchiTietDonHang { get; set; }
        public int IddonHang { get; set; }
        public int IdsanPham { get; set; }
        public int SoLuong { get; set; }

        public decimal ThanhTien { get; set; }

    }



    public class AddCTHD
    {
        public int IddonHang { get; set; }

        public int IdsanPham { get; set; }

        public int SoLuong { get; set; }

        public decimal ThanhTien { get; set; }


    }





}
