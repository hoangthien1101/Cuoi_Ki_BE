using TNN.Data;

namespace TNN.ViewModel
{
    public class LoaiSanPhamVM
    {
        public string? MaLoaiSp { get; set; }

        public string? TenLoaiSp { get; set; }
    }
    public class LoaiSanPhamMD : LoaiSanPhamVM
    {
        public int IdloaiSp { get; set; }       

        public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}
