namespace TNN.ViewModel
{
    public class UpLoadHinhAnhVM
    {

        public int? Iduser { get; set; }

        public string? UrlHinhAnh { get; set; }


    }

    public class UpLoadHinhAnhMD : UpLoadHinhAnhVM
    {
        public int IdHinhNguoiDung { get; set; }
        public bool IsAvata { get; set; }
    }

    public class addhinhanh
    {
        public int? Iduser { get; set; }
        public bool IsAvatar { get; set; }
    }
}
