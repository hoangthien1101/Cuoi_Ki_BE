using TNN.Data;

namespace TNN.ViewModel
{
    public class NhaCungCapVM
    {


        public string TenNhaCungCap { get; set; } = null!;

        public string DiaChi { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string SoDienThoai { get; set; } = null!;

        public virtual ICollection<DonNhap> DonNhaps { get; set; } = new List<DonNhap>();
    }

    public class NhaCungCapMD : NhaCungCapVM
    {
        public int IdnhaCungCap { get; set; }

    }

    public class edit
    {
        public int IdnhaCungCap { get; set; }

        public string TenNhaCungCap { get; set; } = null!;

        public string DiaChi { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string SoDienThoai { get; set; } = null!;
    }
}
