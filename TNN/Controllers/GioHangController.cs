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
    public class GioHangController : ControllerBase
    {
        private readonly IGioHangRepo _giohangRepo;

        public GioHangController(IGioHangRepo giohangRepo)
        {
            _giohangRepo = giohangRepo;

        }
        [Authorize(Roles = "admin")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var giohangs = _giohangRepo.GetAll();
            return Ok(giohangs);
        }

        [HttpGet("GetbyID")]
        public IActionResult GetbyID(int idGiohang)
        {
            var giohangs = _giohangRepo.GetbyID(idGiohang);
            return Ok(giohangs);
        }

        [Authorize(Roles = "admin")] // có quyền 
        [HttpPost("AddGioHang")]
        public IActionResult AddGioHang(AddGioHang giohangVM)
        {
            var giohangs = _giohangRepo.AddGioHang(giohangVM);
            return Ok(giohangs);
        }
        
        [HttpPut("EditGioHang ")]
        public IActionResult EditGioHang(int idgiohang, EditGioHang edit)
        {

            return Ok(_giohangRepo.EditGioHang(idgiohang, edit));

        }
        [HttpDelete("Delete")]
        public IActionResult DeleteGioHang(int idgiohang)
        {
            return Ok(_giohangRepo.DeleteGioHang(idgiohang));
        }
    }
}
