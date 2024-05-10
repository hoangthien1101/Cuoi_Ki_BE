using TNN.Data;

namespace TNN.ViewModel
{
    public class UserVM
    {
        public string? UserName { get; set; }

        public string? MatKhau { get; set; }

        public string? Ho { get; set; }

        public string? Ten { get; set; }

        public string? TenLoaiUser { get; set; }
        public string? Email { get; set; }

        public string? Sdt { get; set; }

        public string? DiaChi { get; set; }

        /// <summary>
        /// 0:Nam 1:Nu
        /// </summary>
        public int? GioiTinh { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgaySua { get; set; }

        public int? Idloai { get; set; }
        public virtual LoaiTaiKhoan? IdloaiNavigation { get; set; }
    }
    public class UserMD : UserVM
    {
        public int Iduser { get; set; }

        public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

        public virtual ICollection<HinhAnhUser> HinhAnhUsers { get; set; } = new List<HinhAnhUser>();

        public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    }

    public class AddUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public int IdLoai { get; set; }
    }
    public class EditUser
    {
        public string Email { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }
        public int? GioiTinh { get; set; }
        public DateTime? NgaySua { get; set; }
    }

    public class DoiMatKhauVM
    {
        public string MatKhauCu { get; set; }
        public string MatKhauMoi { get; set; }
        public string ReMatKhau { get; set; }
    }
    public class RegisterUser
    {
        public string Username { get; set; }
        public string MatKhau { get; set; }
        public string ReMatKhau { get; set; }
        public string Email { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public int? IdLoai { get; set; }
    }
}
