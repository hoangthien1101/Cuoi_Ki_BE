using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TNN.Service;
using TNN.ViewModel;

namespace TNN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var user = _userRepo.GetAll();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepo.GetById(id);
            return user;
        }
        [Authorize(Roles = "admin")]
        [HttpGet("check")]
        public IActionResult CheckUser(string check)
        {
            var user = _userRepo.CheckUser(check);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("User not found");
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPost("adduser")]
        public async Task<JsonResult> AddUser([FromForm] AddUser uservm, List<IFormFile> files)
        {
            var result = await _userRepo.AddUser(uservm, files);
            return result;
        }
        [Authorize(Roles = "admin")]
        [HttpPost("reset/{id}")]
        public IActionResult ResetPassword(int id)
        {
            var result = _userRepo.ResetPass(id);
            return result;
        }

        [HttpPut("DoiMatKhau/{Username}")]
        public IActionResult DoiMatKhau(string Username, DoiMatKhauVM doiMatKhauVM)
        {
            var result = _userRepo.DoiMatKhau(Username, doiMatKhauVM);

            if (result)
            {
                return Ok(new { success = true, message = "Đổi mật khẩu thành công." });
            }
            else
            {
                return BadRequest(new { success = false, message = "Đổi mật khẩu không thành công. Vui lòng kiểm tra lại thông tin." });
            }
        }
        [HttpPut("EditUser/{Username}")]
        public IActionResult EditUser(string Username, EditUser edituser)
        {
            return Ok(_userRepo.EditUser(Username, edituser));
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("DeleteUser/{idUser}")]
        public IActionResult DeleteUser(int idUser)
        {
            return Ok(_userRepo.DeleteUser(idUser));
        }
    }
}
