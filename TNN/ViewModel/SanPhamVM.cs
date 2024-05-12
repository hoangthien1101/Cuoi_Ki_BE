using TNN.Data;

namespace TNN.ViewModel
{
    public class SanPhamVM
    {
        public string MaSp { get; set; } = null!;

        public string TenSp { get; set; } = null!;

        public int IdloaiSp { get; set; }

        public int Idhang { get; set; }

        public decimal Gia { get; set; }

        public int NamSx { get; set; }

        public string CongSuat { get; set; } = null!;

        public string? GhiChu { get; set; }
        public string? TinhTrang { get; set; }
        public int? SoLuong { get; set; }
        public virtual Hang IdhangNavigation { get; set; } = null!;

        public virtual LoaiSp IdloaiSpNavigation { get; set; } = null!;
    }

    public class SanPhamMD : SanPhamVM
    {
        public int IdsanPham { get; set; }       

        public virtual ICollection<ChiTietDonNhap> ChiTietDonNhaps { get; set; } = new List<ChiTietDonNhap>();

        public virtual ICollection<ChiTietGioHangVM> ChiTietGioHangs { get; set; } = new List<ChiTietGioHangVM>();

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

        
    }


    public class AddSP
    {

        public string MaSp { get; set; } = null!;

        public string TenSp { get; set; } = null!;

        public int IdloaiSp { get; set; }

        public int Idhang { get; set; }

        public decimal Gia { get; set; }

        public int NamSx { get; set; }

        public string CongSuat { get; set; } = null!;

        public string? GhiChu { get; set; }
        public string? TinhTrang { get; set; }
        public int? SoLuong { get; set; }
    }

    public class EditSanPham
    {
        public string MaSp { get; set; } = null!;

        public string TenSp { get; set; } = null!;

        public int IdloaiSp { get; set; }

        public int Idhang { get; set; }

        public decimal Gia { get; set; }

        public int NamSx { get; set; }

        public string CongSuat { get; set; } = null!;

        public string? GhiChu { get; set; }
        public string? TinhTrang { get; set; }
        public int? SoLuong { get; set; }
    }

}
