using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TNN.Data;
using TNN.ViewModel;


namespace TNN.Service
{
    public interface IChiTietHoaDonRepo
    {
        List<ChiTietHoaDonMD> GetAll();
        IActionResult AddCTHD(AddCTHD add);
        //IActionResult EditCTHD(ChiTietHoaDonMD edit);
        //IActionResult DeleteCTHD(int idChiTietDonHang);
    }

    public class ChiTietHoaDonRepo : IChiTietHoaDonRepo
    {
        private readonly CuaHangDienLanhContext _context;
        public ChiTietHoaDonRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }

        public List<ChiTietHoaDonMD> GetAll()
        {
            var hoadon = _context.ChiTietHoaDons.Select(u => new ChiTietHoaDonMD
            {
                IdchiTietDonHang = u.IdchiTietDonHang,
                IddonHang = u.IddonHang,
                IdsanPham = u.IdsanPham,
                SoLuong = u.SoLuong,
                ThanhTien = u.ThanhTien


            }).ToList();
            return hoadon;
        }







        public ChiTietHoaDonMD GetById(int IdChitietHoadon)
        {
            var check = _context.ChiTietHoaDons.SingleOrDefault(u => u.IdchiTietDonHang == IdChitietHoadon);
            if (check != null)
            {
                return new ChiTietHoaDonMD
                {
                    IdchiTietDonHang = check.IdchiTietDonHang,
                    IddonHang = check.IddonHang,
                    IdsanPham = check.IdsanPham,
                    SoLuong = check.SoLuong,
                    ThanhTien = check.ThanhTien
                };
            }
            else
            {
                return null;
            }

        }

        public IActionResult AddCTHD(AddCTHD add)
        {
            try
            {
                var CTHD = new ChiTietHoaDon
                {
                    IddonHang = add.IddonHang,
                    IdsanPham = add.IdsanPham,
                    SoLuong = add.SoLuong,
                    ThanhTien = add.ThanhTien
                };
                _context.Add(CTHD);
                _context.SaveChanges();

                return new ObjectResult("Đã khởi tạo")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }
            catch (Exception ex)
            {
                return new JsonResult("Đã tồn tại")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }



        //public IActionResult EditCTHD(ChiTietHoaDonMD edit)
        //{
        //    var check = _context.ChiTietHoaDons.FirstOrDefault(a => a.IdchiTietDonHang == edit.IdchiTietDonHang);
        //    if (check == null)
        //    {
        //        return new JsonResult("Không tìm thấy")
        //        {
        //            StatusCode = StatusCodes.Status404NotFound
        //        };
        //    }
        //    else
        //    {
        //        check.IddonHang = edit.IdchiTietDonHang;
        //        check.IdsanPham = edit.IdsanPham;
        //        check.SoLuong = edit.SoLuong;
        //        check.ThanhTien = edit.ThanhTien;
        //        _context.SaveChanges();

        //        return new JsonResult("Sửa Thành công ")
        //        {
        //            StatusCode = StatusCodes.Status200OK
        //        };

        //    }


        //}


        //public IActionResult DeleteCTHD(int idChiTietDonHang)
        //{
        //    var idctdh = _context.ChiTietHoaDons.SingleOrDefault(l => l.IdchiTietDonHang == idChiTietDonHang);
        //    if (idctdh == null)
        //    {
        //        return new JsonResult("Không có tài khoản cần xóa")
        //        {
        //            StatusCode = StatusCodes.Status404NotFound
        //        };
        //    }
        //    else
        //    {
        //        _context.ChiTietHoaDons.Remove(idctdh);
        //        _context.SaveChanges();

        //        return new JsonResult("Đã xóa")
        //        {
        //            StatusCode = StatusCodes.Status200OK
        //        };
        //    }

        }

    }

