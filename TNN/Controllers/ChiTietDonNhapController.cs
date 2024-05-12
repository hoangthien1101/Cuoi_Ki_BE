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
    public class ChiTietDonNhapController : ControllerBase
    {
        private readonly IChiTietDonNhapRepo _ChiTietDonNhapRepo;

        public ChiTietDonNhapController(IChiTietDonNhapRepo DonNhapRepo)
        {
            _ChiTietDonNhapRepo = DonNhapRepo;

        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var ChiTietDonNhaps = _ChiTietDonNhapRepo.GetAll();
            return Ok(ChiTietDonNhaps);
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetById")]
        public IActionResult GetById(int IdChitietdonnhap)
        {
            var ChiTietDonNhaps = _ChiTietDonNhapRepo.GetById(IdChitietdonnhap);
            return Ok(ChiTietDonNhaps);
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPost("AddChiTietDonNhap")]
        public IActionResult AddChiTietDonNhap(addChiTietDonNhap Add)
        {
            var ChiTietDonNhaps = _ChiTietDonNhapRepo.AddChiTietDonNhap(Add);
            return Ok(ChiTietDonNhaps);
        }
        //[Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        //[HttpPut("Edit")]
        //public IActionResult EditChiTietDonNhap( int IdChitietdonnhap,editChiTietDonNhap edit)
        //{

        //    return Ok(_ChiTietDonNhapRepo.EditChiTietDonNhap(IdChitietdonnhap,edit));

        //}
        //[Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        //[HttpDelete("Delete")]
        //public IActionResult DeleteChiTietDonNhap(int IdChitietdonnhap)
        //{
        //    return Ok(_ChiTietDonNhapRepo.DeleteChiTietDonNhap(IdChitietdonnhap));
        //}
    }

}
