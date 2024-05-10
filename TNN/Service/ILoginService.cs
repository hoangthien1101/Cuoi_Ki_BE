using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TNN.Data;
using TNN.Helpers;

namespace TNN.Service
{
    public interface ILoginService
    {
        JsonResult Login(string username, string matkhau);
    }
    public class LoginServices : ILoginService
    {
        private readonly CuaHangDienLanhContext _context;
        private readonly IConfiguration _config;
        private readonly IUserRepo _userServices;
        private readonly ITokenServices _tokenStorage;

        public LoginServices(IUserRepo userServices, IConfiguration config, ITokenServices tokenStorage, CuaHangDienLanhContext context)
        {
            _context = context;
            _config = config;
            _userServices = userServices;
            _tokenStorage = tokenStorage;
        }

        public JsonResult Login(string username, string matkhau)
        {
            var user = _userServices.CheckUser(username); // kiểm tra user có tồn tại hay ko

            if (user != null)
            {
                bool check = PasswordHasher.verifyPassword(matkhau, user.MatKhau);
                if (check)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);

                    var tokenDesciptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim(ClaimTypes.Role, user.MaLoai),
                        }),
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                    };
                    var token = tokenHandler.CreateToken(tokenDesciptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    //_tokenStorage.TokenStorages.TryAdd((int)user.IdUser, jwtToken);

                    return new JsonResult(jwtToken)
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                return new JsonResult("Mật khẩu không đúng")
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
            return new JsonResult("Username không tồn tại")
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
