using TNN.Data;

namespace TNN.ViewModel
{
    public class HangVM
    {
        public string? TenHang { get; set; }
    }

    public class HangMD:HangVM 
    {
        public int Idhang { get; set; }        

        public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }


    public class AddHang
    {
        public string? TenHang { get; set; }
    }

}
