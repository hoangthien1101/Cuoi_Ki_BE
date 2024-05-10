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
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamRepo _sanPhamRepo;
        public SanPhamController(ISanPhamRepo sanPhamRepo)
        {
            _sanPhamRepo = sanPhamRepo;
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            return Ok(_sanPhamRepo.GetAll());

        }


        [HttpGet("GetByID")]
        public IActionResult GetByID(int IdSanPham)
        {

            return Ok(_sanPhamRepo.GetByID(IdSanPham));

        }

        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPost("addSP")]

        public IActionResult AddSanPham(AddSP add)
        {
            return Ok(_sanPhamRepo.AddSanPham(add));
        }

        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpDelete("DeleteByID")]
        public IActionResult Delete(int IdSanPham)
        {
            return Ok(_sanPhamRepo.DeleteByID(IdSanPham));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPut("EditSanPham")]
        public IActionResult EditSanPham(EditSanPham edit)
        {
            return Ok(_sanPhamRepo.EditSanPham(edit));

        }

        
    }
}
