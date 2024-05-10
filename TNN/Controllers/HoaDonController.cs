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
    public class HoaDonController : ControllerBase
    {

        private readonly IHoaDonRepo _hoaDonRepo;
        public HoaDonController(IHoaDonRepo hoaDonRepo)
        {
            _hoaDonRepo = hoaDonRepo;
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(_hoaDonRepo.GetAll());
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetByiD")]
        public IActionResult GetByID(int IdHoadon, int iduser)
        {
            return Ok(_hoaDonRepo.GetByID(IdHoadon, iduser));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPost("AddHoaDon")]
        public IActionResult AddCTHD(AddHoaDon add)
        {
            var CTHD = _hoaDonRepo.AddHoaDon(add);
            return Ok(CTHD);
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpDelete("DeleteHoaDon")]
        public IActionResult DeleteHoaDon(int idHoadon, int idUser)
        {
            var CTDH = _hoaDonRepo.DeleteHoaDon(idHoadon, idUser);
            return Ok(CTDH);
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPut("EditHD")]
        public IActionResult EditCTDH(Edit edit)
        {
            var CTHD = _hoaDonRepo.EditHoaDon(edit);
            return Ok(CTHD);
        }

    }
}
