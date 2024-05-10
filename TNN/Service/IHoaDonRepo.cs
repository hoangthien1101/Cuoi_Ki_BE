using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface IHoaDonRepo
    {

        List<HoaDonMD> GetAll();
        HoaDonMD GetByID(int IddonHang, int iduser);
        JsonResult AddHoaDon(AddHoaDon add);
        JsonResult DeleteHoaDon(int iddonhag, int iduser);
        JsonResult EditHoaDon(Edit edit);
    }
    public class HoaDonRepo : IHoaDonRepo
    {

        private readonly CuaHangDienLanhContext _context;
        public HoaDonRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }



        public List<HoaDonMD> GetAll()
        {
            var hoadon = _context.HoaDons.Select(u => new HoaDonMD
            {
                IddonHang = u.IddonHang,
                MaDonHang = u.MaDonHang,
                Iduser = u.Iduser,
                NgayDatHang = u.NgayDatHang,
                TongTien = u.TongTien,
                ChiTietHoaDons =u.ChiTietHoaDons,
            }).ToList();
            return hoadon;
        }


        public HoaDonMD GetByID(int IddonHang, int iduser)
        {
            var hoadon = _context.HoaDons.SingleOrDefault(u => u.IddonHang == IddonHang && u.Iduser == iduser);

            if (hoadon != null)
            {
                return new HoaDonMD
                {
                    IddonHang = hoadon.IddonHang,
                    Iduser = hoadon.Iduser,
                    NgayDatHang = hoadon.NgayDatHang,
                    TongTien = hoadon.TongTien,
                };
            }
            else
            {
                return null;
            }
        }

        public JsonResult AddHoaDon(AddHoaDon add)
        {
            var check = _context.HoaDons.SingleOrDefault(a => a.MaDonHang == add.MaDonHang && a.Iduser == add.Iduser);
            if (check == null)
            {
                var CTHD = new HoaDon
                {
                    MaDonHang = add.MaDonHang,
                    Iduser = add.Iduser,
                    NgayDatHang = add.NgayDatHang,
                    TongTien = add.TongTien

                };
                _context.Add(CTHD);
                _context.SaveChanges();

                return new JsonResult("Đã khởi tạo")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }
            else
            {
                return new JsonResult("Đã tồn tại")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        public JsonResult DeleteHoaDon(int iddonhag, int iduser)
        {
            var check = _context.HoaDons.SingleOrDefault(l => l.IddonHang == iddonhag && l.Iduser == iduser);
            if (check == null)
            {
                return new JsonResult("Không có tài khoản cần xóa")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                _context.HoaDons.Remove(check);
                _context.SaveChanges();

                return new JsonResult("Đã xóa")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }

        }

        public JsonResult EditHoaDon(Edit edit)
        {
            var check = _context.HoaDons.FirstOrDefault(a => a.Iduser == edit.Iduser && a.MaDonHang == edit.MaDonHang);
            if (check == null)
            {
                return new JsonResult("Không tìm thấy")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                check.NgayDatHang = edit.NgayDatHang;
                check.TongTien = edit.TongTien;

                _context.SaveChanges();
                return new JsonResult("Sửa Thành công ")
                {
                    StatusCode = StatusCodes.Status200OK
                };

            }

        }


    }
}
