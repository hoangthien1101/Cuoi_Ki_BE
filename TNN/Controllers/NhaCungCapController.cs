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
    public class NhaCungCapController : ControllerBase
    {
        private readonly INhaCungCapRepo _INhaCungCapRepo;
        public NhaCungCapController(INhaCungCapRepo INhaCungCapRepo)
        {
            _INhaCungCapRepo = INhaCungCapRepo;
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {

            return Ok(_INhaCungCapRepo.GetAll());
        }

        [HttpGet("GetByID")]
        public IActionResult GetByID(int id)
        {

            return Ok(_INhaCungCapRepo.GetByID(id));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPost("Add")]
        public IActionResult Add(edit add)
        {

            return Ok(_INhaCungCapRepo.AddNhaCungCap(add));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpPut("Edit")]
        public IActionResult Edit(edit add)
        {

            return Ok(_INhaCungCapRepo.EditNhaCungCap(add));
        }
        [Authorize(Roles = "admin,Nhan Vien")] // có quyền 
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {

            return Ok(_INhaCungCapRepo.Delete(id));
        }


    }
}
