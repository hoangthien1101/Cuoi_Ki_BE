using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface IGioHangRepo
    {
        JsonResult AddGioHang(AddGioHang giohangVM);

        JsonResult DeleteGioHang(int idgiohang);
        JsonResult EditGioHang(int idgiohang, EditGioHang edit);
        List<GioHangMD> GetAll();
        GioHangVM GetbyID(int idGiohang);
    }
    public class GioHangRepo : IGioHangRepo
    {
        private readonly CuaHangDienLanhContext _context;

        public GioHangRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }

        public JsonResult AddGioHang(AddGioHang giohangVM)
        {
            var check = _context.GioHangs.SingleOrDefault(g => g.MaGioHang == giohangVM.MaGioHang && g.IdkhachHang == giohangVM.IdkhachHang);
            if (check == null)
            {
                var giohang = new GioHang
                {
                    IdkhachHang = giohangVM.IdkhachHang,
                    MaGioHang = giohangVM.MaGioHang,
                    TongTien = giohangVM.TongTien,
                };
                _context.GioHangs.Add(giohang);
                _context.SaveChanges();
                return new JsonResult(" Đã khởi tạo giỏ hàng")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new JsonResult(" Đã tồn tại")
                {
                    StatusCode = StatusCodes.Status500InternalServerError

                };
            }

        }

        public JsonResult EditGioHang(int idgiohang,EditGioHang edit)
        {
            var giohang = _context.GioHangs.SingleOrDefault(g => g.IdgioHang == idgiohang);
            if (giohang != null)
            {
                giohang.IdkhachHang = edit.IdkhachHang;
                giohang.MaGioHang = edit.MaGioHang;
                giohang.TongTien = edit.TongTien;

                _context.SaveChanges();
                return new JsonResult(" Đã chinh sua ")
                {
                    StatusCode = StatusCodes.Status200OK
                };
                
            }

            else
            {

                return new JsonResult("Khong tim thay id can chinh sua ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }


        }

        public List<GioHangMD> GetAll()
        {
            var giohangs = _context.GioHangs.Select(g => new GioHangMD
            {
                IdgioHang = g.IdgioHang,
                IdkhachHang = g.IdkhachHang,
                MaGioHang = g.MaGioHang,
                TongTien = g.TongTien,
            }).ToList();
            return giohangs;

        }
        public JsonResult DeleteGioHang(int Idgiohang)
        {
            var giohangs = _context.GioHangs.SingleOrDefault(l => l.IdgioHang == Idgiohang);
            if (giohangs == null)
            {
                return new JsonResult("Không có ID Giỏ hàng để xóa ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                _context.GioHangs.Remove(giohangs);
                _context.SaveChanges();

                return new JsonResult("Đã xóa")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            };
        }

        public GioHangVM GetbyID(int idGiohang)
        {
            var giohangs = _context.GioHangs.SingleOrDefault(l => l.IdgioHang == idGiohang);
            if(giohangs != null)
            {
                return new GioHangVM
                {
                    IdkhachHang = giohangs.IdkhachHang,
                    MaGioHang = giohangs.MaGioHang,
                    TongTien = giohangs.TongTien,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
