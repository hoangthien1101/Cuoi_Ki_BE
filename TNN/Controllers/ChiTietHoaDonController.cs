using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNN.Service;
using TNN.ViewModel;

namespace TNN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietHoaDonController : ControllerBase
    {
        private readonly IChiTietHoaDonRepo _ChiTietHoaDonRepo;
        public ChiTietHoaDonController(IChiTietHoaDonRepo chiTietHoaDonRepo)
        {
            _ChiTietHoaDonRepo = chiTietHoaDonRepo;
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var hoadon = _ChiTietHoaDonRepo.GetAll();
            return Ok(hoadon);

        }

        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetByID")]
        public IActionResult GetByID(int IdChiTietDonHang)
        {
            var hoadon = _ChiTietHoaDonRepo.GetAll();
            return Ok(hoadon);
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPost("AddCTHD")]
        public IActionResult AddCTHD(AddCTHD add)
        {
            var CTHD = _ChiTietHoaDonRepo.AddCTHD(add);
            return Ok(CTHD);
        }
        [Authorize(Roles = "admin")] // có quyền 
        [HttpPut("EditCTDH")]
        public IActionResult EditHoaDon(ChiTietHoaDonMD edit)
        {
            var CTHD = _ChiTietHoaDonRepo.EditCTHD(edit);
            return Ok(CTHD);
        }
        [Authorize(Roles = "admin")] // có quyền 
        [HttpDelete("DeleteCTHD")]
        public IActionResult DeleteCTHD(int IdChiTietDonHang)
        {
            var CTHD = _ChiTietHoaDonRepo.DeleteCTHD(IdChiTietDonHang);
            return Ok(CTHD);
        }




    }
}
