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
    public class LoaiSanPhamController : ControllerBase
    {
        private readonly ILoaiSanPhamRepo _loaiSanPhamRepo;
        public LoaiSanPhamController(ILoaiSanPhamRepo loaiSanPhamRepo)
        {
            _loaiSanPhamRepo = loaiSanPhamRepo;
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            return Ok(_loaiSanPhamRepo.GetAll());
        }

        [HttpGet("GetByID")]
        public IActionResult GetByID(int idLoaiSP)
        {
            return Ok(_loaiSanPhamRepo.GetByID(idLoaiSP));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPost("Thêm loại sản phầm")]
        public IActionResult AddLoaiSP(LoaiSanPhamVM loaiSanPhamVM)
        {
            return Ok(_loaiSanPhamRepo.AddLoaiSP(loaiSanPhamVM));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPut("Sửa loại sản phẩm")]
        public IActionResult Edit(int idloaisp, LoaiSanPhamVM loaiSanPhamVM)
        {
            return Ok(_loaiSanPhamRepo.Edit(idloaisp, loaiSanPhamVM));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpDelete("Xóa loại sản phẩm")]

        public IActionResult Delete(int idloaisp)
        {
            return Ok(_loaiSanPhamRepo.Delete(idloaisp));
        }
    }
}
