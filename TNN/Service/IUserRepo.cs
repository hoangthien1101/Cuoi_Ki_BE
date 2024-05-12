using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TNN.Data;
using TNN.ViewModel;
using TNN.Helpers;


namespace TNN.Service
{
    public interface IUserRepo
    {
        Task<JsonResult> AddUser(AddUser userVM, List<IFormFile> files);
        JsonResult ResetPass(int idUser);
        List<UserMD> GetAll();
        JsonResult GetById(int idUser);
        LoginVM CheckUser(string check);
        JsonResult DeleteUser(int idUser);
        JsonResult EditUser(string username, EditUser edituser);
        bool DoiMatKhau(string username, DoiMatKhauVM doiMatKhauVM);
        JsonResult RegisterUser(RegisterUser registerUser);
    }
    public class UserRepo : IUserRepo
    {
        private readonly IWriteFileRepository _writeFile;
        private readonly IUpLoadHinhAnhRepo _upLoadHinhAnhRepo;
        private readonly CuaHangDienLanhContext _context;
        private readonly ISendMailService _sendEmail;
        private readonly IGioHangRepo _giohangRepo;
        public UserRepo( CuaHangDienLanhContext context, ISendMailService sendEmail, IWriteFileRepository writeFile, IUpLoadHinhAnhRepo upLoadHinhAnhRepo, IGioHangRepo giohangRepo) 
        {
            _context = context;
            _sendEmail = sendEmail;
            _writeFile = writeFile;
            _upLoadHinhAnhRepo = upLoadHinhAnhRepo;
            _giohangRepo = giohangRepo;
        }

        public List<UserMD> GetAll()
        {
            var user = _context.Users.Select(u => new UserMD
            {
                Iduser = u.Iduser,
                UserName = u.UserName,
                Ho = u.Ho,
                Ten = u.Ten,
                Idloai = u.Idloai,
                TenLoaiUser = u.IdloaiNavigation.TenLoai,
            }).ToList();
            return user;
        }

        public JsonResult GetById(int idUser)
        {
            var user = _context.Users.Include(u => u.IdloaiNavigation).FirstOrDefault(u => u.Iduser == idUser);
            var _user = new UserVM
            {
                UserName = user.UserName,
                Ho = user.Ho,
                Ten = user.Ten,
                Idloai = user.Idloai,
                TenLoaiUser = user.IdloaiNavigation.TenLoai,
                Email = user.Email,
            };
            return new JsonResult(_user);
        }
        public LoginVM CheckUser(string? check = null)
        {
            var user = _context.Users.Include(c => c.IdloaiNavigation).FirstOrDefault(c => c.UserName == check || c.Email == check);
            if (user != null)
            {
                var _user = new LoginVM
                {
                    Username = user.UserName,
                    MatKhau = user.MatKhau,
                    MaLoai = user.IdloaiNavigation.MaLoai,
                };
                return _user;
            }
            return null;
        }

        private void taogiohang(int iduser,string magiohang, decimal tongtine)
        {
            var giohang = new GioHang
            {
                IdkhachHang = iduser,
                MaGioHang = magiohang,
                TongTien = tongtine,
            };
            _context.GioHangs.Add(giohang);
            _context.SaveChanges();
        }


        public async Task<JsonResult> AddUser(AddUser userVM, List<IFormFile> files)
        {
            if (CheckUser(userVM.Username) == null)
            {
                string password = PasswordHasher.GetRandomPassword();

                var user = new User
                {
                    UserName = userVM.Username,
                    MatKhau = PasswordHasher.HashPassword(password),
                    Email = userVM.Email,
                    Ho = userVM.Ho,
                    Ten = userVM.Ten,
                    NgayTao = DateTime.Now,
                    Idloai = userVM.IdLoai,
                };               
                _context.Users.Add(user);
                _context.SaveChanges();

                int IdUser = user.Iduser;
                string folder = "Users";

                List<string> imageUrls = await _writeFile.WriteFileAsync(files, folder);
                if (imageUrls.Count != 0)
                {
                    foreach (var url in imageUrls)
                    {
                        var image = new HinhAnhUser
                        {
                            Iduser = IdUser,
                            UrlHinhAnh = url
                        };
                        _context.HinhAnhUsers.Add(image);
                    }
                    _context.SaveChanges();
                }

                int IDUser = user.Iduser;
                string magiohang = "GH" + IDUser;
                decimal tongtien = 0;
                taogiohang(IDUser, magiohang, tongtien);

                var email = new EmailModel
                {
                    FromEmail = "hoangthien110104@gmail.com",
                    ToEmail = userVM.Email,
                    Subject = "Tài khoản của bạn đã được khởi tạo bởi quản trị viên",
                    Body = "Thông tin đăng nhập: " +
                    "- Username: " + userVM.Username + "" +
                    "- Mật khẩu: " + password,
                };
                _sendEmail.SendEmail(email);
                //_mailHelpers.Send(email.FromEmail, userVM.Email, email.Subject, email.Body);

                return new JsonResult("Đã khởi tạo User")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }
            else
            {
                return new JsonResult("Username đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
        public JsonResult ResetPass(int idUser)
        {
            var check = _context.Users.FirstOrDefault(u => u.Iduser == idUser);
            if (check == null)
            {
                return new JsonResult("User không tồn tại")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                string password = PasswordHasher.GetRandomPassword();
                check.MatKhau = PasswordHasher.HashPassword(password);
                _context.SaveChanges();
                var email = new EmailModel
                {
                    FromEmail = "hoangthien110104@gmail.com",
                    ToEmail = check.Email,
                    Subject = "Quản trị viên đã reset mật khẩu của bạn",
                    Body = "Thông tin đăng nhập: " +
                    "- Username: " + check.UserName + "" +
                    "- Mật khẩu: " + password,
                };
                _sendEmail.SendEmail(email);
                //_mailHelpers.Send(email.FromEmail, email.ToEmail, email.Subject, email.Body);
                return new JsonResult("Đã Reset")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }
        public JsonResult DeleteUser(int idUser)
        {
            var user = _context.Users.SingleOrDefault(l => l.Iduser == idUser);
            if (user == null)
            {
                return new JsonResult("Không có tài khoản cần xóa")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                var img = _context.HinhAnhUsers.Where(i => i.Iduser == idUser).ToList();
                // Xóa từng hình ảnh
                foreach (var image in img)
                {
                    _context.HinhAnhUsers.Remove(image);
                }
                _context.Users.Remove(user);
                _context.SaveChanges();

                return new JsonResult("Đã xóa")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            };
        }

        public JsonResult EditUser(string username, EditUser edituser)
        {
            var check = _context.Users.FirstOrDefault(c => c.UserName == username);
            if(check != null)
            {
                check.Ho = edituser.Ho;
                check.Ten = edituser.Ten;
                check.Email = edituser.Email;
                check.DiaChi = edituser.DiaChi;
                check.Sdt = edituser.Sdt;
                check.GioiTinh = edituser.GioiTinh;
                check.NgaySua=DateTime.Now;
                _context.SaveChanges();
                return new JsonResult("Đã chỉnh sửa  ")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new JsonResult("Không tìm thấy loại cần chỉnh sửa ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }

        public bool DoiMatKhau(string username, DoiMatKhauVM doiMatKhauVM)
        {
            var user = _context.Users.FirstOrDefault(c => c.UserName == username);

            // Nếu người dùng tồn tại
            if (user != null)
            {
                // Kiểm tra xem mật khẩu cũ có khớp với mật khẩu đã lưu trong cơ sở dữ liệu hay không
                if (PasswordHasher.verifyPassword( doiMatKhauVM.MatKhauCu,user.MatKhau))
                {
                    // Kiểm tra mật khẩu mới và mật khẩu nhập lại có khớp nhau hay không
                    if (doiMatKhauVM.MatKhauMoi == doiMatKhauVM.ReMatKhau)
                    {

                        // Mật khẩu mới hợp lệ, mã hóa mật khẩu mới trước khi lưu vào cơ sở dữ liệu
                        user.MatKhau = PasswordHasher.HashPassword(doiMatKhauVM.MatKhauMoi);

                        // Lưu các thay đổi vào cơ sở dữ liệu
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public JsonResult RegisterUser(RegisterUser registerUser)
        {
            var check = _context.Users.SingleOrDefault(c => c.UserName == registerUser.Username);
            if (check == null)
            {
                if (registerUser.MatKhau == registerUser.ReMatKhau)
                {
                    var user = new User
                    {

                        UserName = registerUser.Username,
                        MatKhau = PasswordHasher.HashPassword(registerUser.MatKhau),
                        Email = registerUser.Email,
                        Ho=registerUser.Ho,
                        Ten=registerUser.Ten,
                        NgayTao = DateTime.Now,
                        Idloai = 4,
                    };
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    int IDUser = user.Iduser;
                    string magiohang = "GH" + IDUser;
                    decimal tongtien = 0;
                    taogiohang(IDUser, magiohang, tongtien);
                }
                else
                {
                    return new JsonResult("Mật khẩu nhập lại không chính xác")
                    {
                        StatusCode = StatusCodes.Status400BadRequest
                    };
                }
                return new JsonResult("Đăng kí thành công")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new JsonResult("UserName đã tồn tại")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
