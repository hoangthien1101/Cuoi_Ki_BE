using TNN.Data;

namespace TNN.ViewModel
{
    public class LoaiVM
    {
        public string? MaLoai { get; set; }

        public string? TenLoai { get; set; }
    }
    public class LoaiMD : LoaiVM 
    {
        public int Idloai { get; set; }       

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }    
}
