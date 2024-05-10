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
    public class ChiTietGioHangController : ControllerBase
    {

        private readonly IChiTietGioHangRepo _ChiTietGioHangRepo;
        public ChiTietGioHangController(IChiTietGioHangRepo ChiTietGioHangRepo)
        {
            _ChiTietGioHangRepo = ChiTietGioHangRepo;
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var ChiTietGioHangs = _ChiTietGioHangRepo.GetAll();
            return Ok(ChiTietGioHangs);
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetById")]

        public IActionResult GetById(int idChitietgiohang)
        {
            return Ok(_ChiTietGioHangRepo.GetById(idChitietgiohang));
        }
        [HttpPost("AddChiTietGioHang")]
        public IActionResult AddChiTietGioHang(AddChiTietGioHang addChiTietGioHang)
        {
            var ChiTietGioHangs = _ChiTietGioHangRepo.AddChiTietGioHang(addChiTietGioHang);
            return Ok(ChiTietGioHangs);
        }
        [HttpPut("EditIdgioHang/IdgioHang ")]
        public IActionResult EditChiTietGioHang(int idChiTietGioHang, editChiTietGioHang edit)
        {

            return Ok(_ChiTietGioHangRepo.EditChiTietGioHang(idChiTietGioHang,edit));

        }
        [HttpDelete("DeleteIdgioHang/{IdgioHang}")]
        public IActionResult DeleteChiTietGioHang(int IdgioHang)
        {
            return Ok(_ChiTietGioHangRepo.DeleteGioHang(IdgioHang));
        }
    }
}
