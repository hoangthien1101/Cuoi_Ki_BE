using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TNN.Service;
using TNN.ViewModel;

namespace TNN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpLoadHinhAnhController : ControllerBase
    {
        private readonly IUpLoadHinhAnhRepo _upLoadHinhAnhRepo;
        public UpLoadHinhAnhController(IUpLoadHinhAnhRepo upLoadHinhAnhRepo)
        {
            _upLoadHinhAnhRepo = upLoadHinhAnhRepo;
        }
        #region UpLoad
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] List<IFormFile> files, [FromForm] addhinhanh Addhinhanh, string folder = "")
        {
            try
            {
                var imageUrls = await _upLoadHinhAnhRepo.WriteFileAsync(files, Addhinhanh, folder);
                return Ok(imageUrls);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion
    }
}
