using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface ILoaiSanPhamRepo
    {
        JsonResult AddLoaiSP(LoaiSanPhamVM loaiSanPhamVM);
        JsonResult Delete(int idloaisp);
        JsonResult Edit(int idloaisp, LoaiSanPhamVM loaiSanPhamVM);
        List<LoaiSanPhamMD> GetAll();
        LoaiSanPhamVM GetByID(int idLoaiSP);
    }
    public class LoaiSanPhamRepo : ILoaiSanPhamRepo
    {
        private readonly CuaHangDienLanhContext _context;
        public LoaiSanPhamRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }

        public JsonResult AddLoaiSP(LoaiSanPhamVM loaiSanPhamVM)
        {
            var check = _context.LoaiSps.SingleOrDefault(c => 
                              c.MaLoaiSp == loaiSanPhamVM.MaLoaiSp || c.TenLoaiSp == loaiSanPhamVM.TenLoaiSp);
            if(check == null)
            {
                var loaisp = new LoaiSp
                {
                    TenLoaiSp = loaiSanPhamVM.TenLoaiSp,
                    MaLoaiSp = loaiSanPhamVM.MaLoaiSp,  
                };
                _context.LoaiSps.Add(loaisp);
                _context.SaveChanges();
                return new JsonResult("Đã khởi tạo loại sản phẩm ")
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

        public JsonResult Delete(int idloaisp)
        {
            var check = _context.LoaiSps.SingleOrDefault(c => c.IdloaiSp == idloaisp);
            if (check != null)
            {
                _context.LoaiSps.Remove(check);
                _context.SaveChanges();
                return new JsonResult("Đã xóa")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new JsonResult("Không có hãng cần xóa")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }

        public JsonResult Edit(int idloaisp, LoaiSanPhamVM loaiSanPhamVM)
        {
            var check = _context.LoaiSps.SingleOrDefault(c => c.IdloaiSp == idloaisp);
            if (check != null)
            {
                check.MaLoaiSp = loaiSanPhamVM.MaLoaiSp;
                check.TenLoaiSp = loaiSanPhamVM.TenLoaiSp;
                _context.SaveChanges();
                return new JsonResult("Đã sửa")
                {
                    StatusCode = StatusCodes.Status200OK
                };

            }
            else
            {
                return new JsonResult("Không có loại sản phẩm cần sửa")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }

        public List<LoaiSanPhamMD> GetAll()
        {
            var LoaiSp = _context.LoaiSps.Select(l => new LoaiSanPhamMD
            {
                IdloaiSp = l.IdloaiSp,
                MaLoaiSp = l.MaLoaiSp,
                TenLoaiSp = l.TenLoaiSp,
            }).ToList();
            return LoaiSp;
        }

        public LoaiSanPhamVM GetByID(int idLoaiSP)
        {
            var LoaiSP = _context.LoaiSps.FirstOrDefault(c => c.IdloaiSp == idLoaiSP);
            if (LoaiSP != null)
            {
                return new LoaiSanPhamVM
                {
                    TenLoaiSp = LoaiSP.TenLoaiSp,
                    MaLoaiSp = LoaiSP.MaLoaiSp,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
