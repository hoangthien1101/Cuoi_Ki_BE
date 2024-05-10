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
    public class DonNhapController : ControllerBase
    {
        private readonly IDonNhapRepo _DonNhapRepo;

        public DonNhapController(IDonNhapRepo DonNhapRepo)
        {
            _DonNhapRepo = DonNhapRepo;

        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var DonNhaps = _DonNhapRepo.GetAll();
            return Ok(DonNhaps);
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetById")]
        public IActionResult GetById(int iddonnhap)
        {
            var DonNhaps = _DonNhapRepo.GetById(iddonnhap);
            return Ok(DonNhaps);
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPost("AddDonNhap")]
        public IActionResult AddDonNhap(AddDonNhap addDonNhap)
        {
            var DonNhaps = _DonNhapRepo.AddDonNhap(addDonNhap);
            return Ok(DonNhaps);
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPut("Edit")]
        public IActionResult DonNhap(int iddonnhap, EditDonNhap edit)
        {

            return Ok(_DonNhapRepo.EditDonNhap(iddonnhap,edit));

        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpDelete("Delete")]
        public IActionResult DeleteDonNhap(int idDonNhap)
        {
            return Ok(_DonNhapRepo.DeleteDonNhap(idDonNhap));
        }
    }
}
