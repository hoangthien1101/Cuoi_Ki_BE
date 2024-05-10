using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.Service;
using TNN.ViewModel;

namespace TNN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginServices;
        private readonly IUserRepo _userRepo;

        public LoginController(ILoginService loginServices, IUserRepo userRepo)
        {
            _loginServices = loginServices;
            _userRepo = userRepo;
        }
        [HttpPost]
        public IActionResult Login(string username, string matkhau)
        {
            return Ok(_loginServices.Login(username, matkhau));
        }
        [HttpPost("Đăng kí tài khoản")]
        public IActionResult RegisterUser([FromForm]RegisterUser registerUser)
        {
            return Ok(_userRepo.RegisterUser(registerUser));
    }
    }
    
}
