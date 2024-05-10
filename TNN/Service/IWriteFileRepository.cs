using TNN.Data;

namespace TNN.Service
{
    public interface IWriteFileRepository
    {
        Task<List<string>> WriteFileAsync(List<IFormFile> files, string folderName);
    }
    public class WriteFileRepository : IWriteFileRepository
    {
        private readonly CuaHangDienLanhContext _context;
        public WriteFileRepository(CuaHangDienLanhContext context)
        {
            _context = context;
        }
        public async Task<List<string>> WriteFileAsync(List<IFormFile> files, string folderName )
        {
            #region

            var urls = new List<string>();
            foreach (var file in files)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                urls.Add($"{folderName}/{uniqueFileName}");
            }
            return urls;
            #endregion
            
        }
    }
}
