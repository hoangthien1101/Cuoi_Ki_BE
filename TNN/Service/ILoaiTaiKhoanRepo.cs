using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface ILoaiTaiKhoanRepo
    {
        JsonResult AddLoai(LoaiVM loaiVM);
        JsonResult DeleteLoai(int idLoai);
        JsonResult EditLoai(int idLoai, LoaiVM loaiVM);
        List<LoaiMD> GetAll();
        LoaiVM GetByID(int idLoaiUser);
    }
    public class LoaiTaiKhoanRepo : ILoaiTaiKhoanRepo
    {
        private readonly CuaHangDienLanhContext _context;
        public LoaiTaiKhoanRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }

        public JsonResult AddLoai(LoaiVM loaiVM)
        {
            var check = _context.LoaiTaiKhoans.SingleOrDefault(l => l.TenLoai == loaiVM.TenLoai || l.MaLoai == loaiVM.MaLoai);
            if (check == null)
            {
                var loai = new LoaiTaiKhoan
                {
                    TenLoai = loaiVM.TenLoai,
                    MaLoai = loaiVM.MaLoai,
                };
                _context.LoaiTaiKhoans.Add(loai);
                _context.SaveChanges();
                return new JsonResult("Đã khởi tạo loại user ")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }
            else
            {
                return new JsonResult("Đã tồn tại ")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public JsonResult DeleteLoai(int idLoai)
        {
            var loai = _context.LoaiTaiKhoans.SingleOrDefault(l => l.Idloai == idLoai);
            if (loai == null)
            {
                return new JsonResult("Không có loại tài khoản cần xóa")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                _context.LoaiTaiKhoans.Remove(loai);
                _context.SaveChanges();

                return new JsonResult("Đã xóa")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            };
        }

        public JsonResult EditLoai(int idLoai, LoaiVM loaiVM)
        {
            var loai = _context.LoaiTaiKhoans.SingleOrDefault(l => l.Idloai == idLoai);
            if (loai == null)
            {
                return new JsonResult("Không tìm thấy loại cần chỉnh sửa ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                loai.TenLoai = loaiVM.TenLoai;
                loai.MaLoai = loaiVM.MaLoai;
                _context.SaveChanges();

                return new JsonResult("Đã chỉnh sửa  ")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
        }

        public List<LoaiMD> GetAll()
        {
            var Loais = _context.LoaiTaiKhoans.Select(l => new LoaiMD
            {
                Idloai = l.Idloai,
                MaLoai = l.MaLoai,
                TenLoai = l.TenLoai,
            }).ToList();
            return Loais;
        }


        public LoaiVM GetByID(int idLoaiUser)
        {
            var check = _context.LoaiTaiKhoans.FirstOrDefault(l => l.Idloai == idLoaiUser);
            if (check != null)
            {
                return new LoaiVM
                {
                    MaLoai = check.MaLoai,
                    TenLoai = check.TenLoai,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
