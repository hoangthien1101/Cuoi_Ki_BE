using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface IChiTietDonNhapRepo
    {
        List<ChiTietDonNhapMD> GetAll();
        JsonResult AddChiTietDonNhap(addChiTietDonNhap Add);
        JsonResult EditChiTietDonNhap(int IdChitietdonnhap, editChiTietDonNhap edit);
        JsonResult DeleteChiTietDonNhap(int IdChitietdonnhap);
        ChiTietDonNhapVM GetById(int idChitietdonnhap);
    }
    public class ChiTietDonNhapRepo : IChiTietDonNhapRepo
    {
        private readonly CuaHangDienLanhContext _context;

        public ChiTietDonNhapRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }

        public JsonResult AddChiTietDonNhap(addChiTietDonNhap Add)
        {
            var check = _context.ChiTietDonNhaps.SingleOrDefault(l => l.IddonNhap == Add.IddonNhap);
            if (check == null)
            {
                var ChiTietDonNhaps = new ChiTietDonNhap
                {
                    IddonNhap = Add.IddonNhap,
                    IdsanPham = Add.IdsanPham,
                    DonGia = Add.DonGia,
                    SoLuong = Add.SoLuong,
                    ThanhTien = Add.ThanhTien,
                };
                _context.ChiTietDonNhaps.Add(ChiTietDonNhaps);
                _context.SaveChanges();
                return new JsonResult(" Đã khởi tạo chi tiết đơn nhập")
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

        public JsonResult DeleteChiTietDonNhap(int IdChitietdonnhap)
        {
            var ChiTietDonNhaps = _context.ChiTietDonNhaps.SingleOrDefault(l => l.IdchiTietDonNhap == IdChitietdonnhap);
            if (ChiTietDonNhaps == null)
            {
                return new JsonResult("Không có chi tiết đơn nhập để xóa ")
                {
                    StatusCode = StatusCodes.Status404NotFound

                };
            }
            else
            {
                _context.ChiTietDonNhaps.Remove(ChiTietDonNhaps);
                _context.SaveChanges();

                return new JsonResult("Đã xóa")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            };
        }

        public JsonResult EditChiTietDonNhap(int IdChitietdonnhap, editChiTietDonNhap edit)
        {
            var ChiTietDonNhaps = _context.ChiTietDonNhaps.SingleOrDefault(l => l.IdchiTietDonNhap == IdChitietdonnhap);
            {

                if (ChiTietDonNhaps == null)

                    return new JsonResult("Không tìm thấy chi tiết đơn nhập để sửa")
                    {
                        StatusCode = StatusCodes.Status404NotFound
                    };
                else
                {

                    ChiTietDonNhaps.IdsanPham = edit.IdsanPham;


                    _context.SaveChanges();
                    return new JsonResult(" Đã chinh sua ")
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
            }
        }

        public List<ChiTietDonNhapMD> GetAll()
        {
            var ChiTietDonNhaps = _context.ChiTietDonNhaps.Select(l => new ChiTietDonNhapMD
            {
                IddonNhap = l.IddonNhap,
                SoLuong = l.SoLuong,
                IdsanPham = l.IdsanPham,
                IdchiTietDonNhap = l.IdchiTietDonNhap,
                DonGia = l.DonGia,
                ThanhTien = l.ThanhTien
            }).ToList();
            return ChiTietDonNhaps;
        }

        public ChiTietDonNhapVM GetById(int idChitietdonnhap)
        {
            var ChiTietDonNhaps = _context.ChiTietDonNhaps.SingleOrDefault(l => l.IdchiTietDonNhap == idChitietdonnhap);
            if(ChiTietDonNhaps != null)
            {
                return new ChiTietDonNhapVM
                {
                    IddonNhap = ChiTietDonNhaps.IddonNhap,
                    SoLuong = ChiTietDonNhaps.SoLuong,
                    IdsanPham = ChiTietDonNhaps.IdsanPham,
                    DonGia = ChiTietDonNhaps.DonGia,
                    ThanhTien = ChiTietDonNhaps.ThanhTien
                };
            }
            else
            {
                return null;
            }
        }
    }
}
