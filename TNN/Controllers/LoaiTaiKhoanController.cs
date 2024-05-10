using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNN.Service;
using TNN.ViewModel;

namespace TNN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoaiTaiKhoanController : ControllerBase
    {
        private readonly ILoaiTaiKhoanRepo _loaitaikhoanrepo;
        public LoaiTaiKhoanController(ILoaiTaiKhoanRepo loaitaikhoanrepo)
        {
            _loaitaikhoanrepo = loaitaikhoanrepo;
        }
        [Authorize(Roles = "admin")] // có quyền 
        [HttpGet("Get all")]
        public IActionResult GetAll()
        {
            var Loais = _loaitaikhoanrepo.GetAll();
            return Ok(Loais);
        }
        [Authorize(Roles = "admin")] // có quyền 
        [HttpGet("GetByID/{idLoaiUser}")]
        public IActionResult GetByID(int idLoaiUser)
        {
            var loais = _loaitaikhoanrepo.GetByID(idLoaiUser);
            return Ok(loais);
        }
        [Authorize(Roles = "admin")] // có quyền 
        [HttpPost("AddLoaiUser")]
        public IActionResult AddLoaiUser(LoaiVM loaiVM)
        {
            var loai = _loaitaikhoanrepo.AddLoai(loaiVM);
            return Ok(loai);
        }
        [Authorize(Roles = "admin")] // có quyền 
        [HttpPut("EditLoai/{idLoai}")]
        public IActionResult EditLoaiUser(int idLoai, LoaiVM loaiVM)
        {
            return Ok(_loaitaikhoanrepo.EditLoai(idLoai, loaiVM));
        }
        [Authorize(Roles = "admin")] // có quyền 
        [HttpDelete("DeleteLoai/{idLoai}")]
        public IActionResult DeleteLoaiUser(int idLoai)
        {
            return Ok(_loaitaikhoanrepo.DeleteLoai(idLoai));
        }

    }
}
