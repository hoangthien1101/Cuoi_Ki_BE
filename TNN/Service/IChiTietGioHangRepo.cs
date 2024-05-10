using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.Service;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface IChiTietGioHangRepo
    {
        List<ChiTietGioHangMD> GetAll();
        JsonResult AddChiTietGioHang(AddChiTietGioHang addChiTietGioHang);
        JsonResult EditChiTietGioHang(int idChiTietGioHang, editChiTietGioHang edit);
        JsonResult DeleteGioHang(int IdgioHang);
        ChiTietGioHangVM GetById(int idChitietgiohang);
    }
    public class ChiTietGioHangRepo : IChiTietGioHangRepo
    {
        private readonly CuaHangDienLanhContext _context;

        public ChiTietGioHangRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }

        public JsonResult AddChiTietGioHang(AddChiTietGioHang addChiTietGioHang)
        {
            try
            {

                var ChiTietGioHang = new ChiTietGioHang
                {
                    IdgioHang = addChiTietGioHang.IdgioHang,
                    IdsanPham = addChiTietGioHang.IdsanPham,
                    SoLuong = addChiTietGioHang.SoLuong,
                    ThanhTien = addChiTietGioHang.ThanhTien,
                };
                _context.ChiTietGioHangs.Add(ChiTietGioHang);
                _context.SaveChanges();
                return new JsonResult(" Đã khởi tạo chi tiết giỏ hàng")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }

            catch (Exception ex)
            {
                {
                    return new JsonResult(" Đã tồn tại")
                    {
                        StatusCode = StatusCodes.Status500InternalServerError

                    };
                }
            }
        }

        public JsonResult DeleteGioHang(int IdgioHang)
        {
            var ChiTietGioHangs = _context.ChiTietGioHangs.SingleOrDefault(l => l.IdgioHang == IdgioHang);
            if (ChiTietGioHangs == null)
            {
                return new JsonResult("Không có ID giỏ hàng để xóa ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                _context.ChiTietGioHangs.Remove(ChiTietGioHangs);
                _context.SaveChanges();

                return new JsonResult("Đã xóa")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            };
        }

        public JsonResult EditChiTietGioHang(int idChiTietGioHang, editChiTietGioHang edit)
        {
            var ChiTietGioHang = _context.ChiTietGioHangs.SingleOrDefault(g => g.IdchiTietGioHang == idChiTietGioHang);

            if (ChiTietGioHang == null)
            {

                return new JsonResult("Không tìm thấy id cần chỉnh sửa ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                ChiTietGioHang.IdsanPham = edit.IdsanPham;
                ChiTietGioHang.SoLuong = edit.SoLuong;
                ChiTietGioHang.ThanhTien = edit.ThanhTien;
                _context.SaveChanges();
                return new JsonResult(" Đã chỉnh sửa ")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }


        }

        public List<ChiTietGioHangMD> GetAll()
        {
            var ChiTietGioHangs = _context.ChiTietGioHangs.Select(l => new ChiTietGioHangMD
            {
                IdchiTietGioHang = l.IdchiTietGioHang,
                IdgioHang = l.IdgioHang,
                IdsanPham = l.IdsanPham,
                SoLuong = l.SoLuong,
                ThanhTien   = l.ThanhTien,
                
            }).ToList();
            return ChiTietGioHangs;
        }
        public ChiTietGioHangVM GetById(int idchiTietGioHang)
        {
            var ChiTietGioHang = _context.ChiTietGioHangs.SingleOrDefault(l => l.IdchiTietGioHang == idchiTietGioHang);
            if (ChiTietGioHang != null)
            {
                return new ChiTietGioHangVM
                {
                    IdgioHang = ChiTietGioHang.IdgioHang,
                    IdsanPham = ChiTietGioHang.IdsanPham,
                    SoLuong = ChiTietGioHang.SoLuong,
                    ThanhTien = ChiTietGioHang.ThanhTien,
                };
            }
            else
            {
                return null;
            }
        }

    }
}
