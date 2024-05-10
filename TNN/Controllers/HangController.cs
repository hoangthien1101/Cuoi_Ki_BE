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
    public class HangController : ControllerBase
    {
        private readonly IHangRepo _hangRepo;
        public HangController(IHangRepo hangRepo)
        {
            _hangRepo = hangRepo;
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_hangRepo.GetAll());
        }

        [HttpGet("GetByID")]
        public IActionResult GetByID(int idhang)
        {
            return Ok(_hangRepo.GetByID(idhang));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPost("Add Hãng")]
        public IActionResult Addhang(AddHang addHang)
        {
            return Ok(_hangRepo.Addhang(addHang));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPut("Edit Hãng")]
        public IActionResult Edit(int idhang , AddHang addHang)
        {
            return Ok(_hangRepo.Edit(idhang, addHang));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpDelete("Xóa Hãng")]

        public IActionResult Delete(int idhang)
        {
            return Ok(_hangRepo.Delete(idhang));
        }
    }
}
