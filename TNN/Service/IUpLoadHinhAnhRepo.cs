using TNN.Data;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface IUpLoadHinhAnhRepo
    {
        Task<List<string>> WriteFileAsync(List<IFormFile> files, addhinhanh Addhinhanh, string folder);
    }
    public class UpLoadHinhAnhRepo : IUpLoadHinhAnhRepo
    {
        private readonly CuaHangDienLanhContext _context;
        public UpLoadHinhAnhRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }
        #region Upload
        public async Task<List<string>> WriteFileAsync(List<IFormFile> files, addhinhanh Addhinhanh, string folder)
        {
            string local;
            var imageUrls = new List<string>();
            var errorMessages = new List<string>(); // Danh sách để lưu trữ thông báo lỗi

            foreach (var file in files)
            {
                if (file.Length == 0)
                {
                    continue;
                }

                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

                if (extension == ".jpg" || extension == ".jpge" || extension == ".png")
                {
                    local = "Images";
                }
                else if (extension == ".pdf" || extension == ".doc" || extension == ".docx" || extension == ".xls" || extension == ".xlsx")
                {
                    local = "Files";
                }
                else
                {
                    // Nếu extension không hợp lệ, thêm thông báo lỗi vào danh sách và chuyển sang file tiếp theo
                    errorMessages.Add($"File không hợp lệ '{file.FileName}'.");
                    continue;
                }

                try
                {
                    var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "UpLoad\\" + local + folder + "\\" + "", file.FileName);
                    //var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "UpLoad", local, folder, file.FileName);

                    var stream = new FileStream(exactpath, FileMode.Create);

                    await file.CopyToAsync(stream);

                    stream.Close();

                    string result = "Upload/" + local + "/" + folder + "/" + file.FileName;

                    imageUrls.Add(result);
                }
                catch (Exception ex)
                {
                    errorMessages.Add($"Lỗi khi upload file '{file.FileName}': {ex.Message}");
                }
            }
            // Kiểm tra nếu có lỗi, trả về danh sách thông báo lỗi
            if (errorMessages.Count > 0)
            {
                throw new Exception(string.Join(Environment.NewLine, errorMessages));
            }
            // Lưu thông tin hình ảnh vào cơ sở dữ liệu
            foreach (var imageUrl in imageUrls)
            {
                var image = new HinhAnhUser
                {
                    UrlHinhAnh = imageUrl,
                    Iduser = Addhinhanh.Iduser,
                    IsAvt = Addhinhanh.IsAvatar,
                };
                _context.HinhAnhUsers.Add(image);
            }
            await _context.SaveChangesAsync();
            return imageUrls;
        }
        #endregion
    }
}
