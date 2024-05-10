using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface IDonNhapRepo
    {
        JsonResult AddDonNhap(AddDonNhap addDonNhap);
        List<DonNhapMD> GetAll();
        JsonResult EditDonNhap(int iddonnhap, EditDonNhap edit);
        JsonResult DeleteDonNhap(int idDonNhap);
        DonNhapVM GetById(int iddonnhap);
    }
    public class DonNhapRepo : IDonNhapRepo
    {
        private readonly CuaHangDienLanhContext _context;

        public DonNhapRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }

        public JsonResult AddDonNhap(AddDonNhap addDonNhap)
        {
            try
            {
                var DonNhaps = new DonNhap
                {
                    IdnhaCungCap = addDonNhap.IdnhaCungCap,
                    TongTien = addDonNhap.TongTien,
                    NgayNhap = DateTime.Now,
                    Iduser = addDonNhap.Iduser
                };
                _context.DonNhaps.Add(DonNhaps);
                _context.SaveChanges();
                return new JsonResult(" Đã khởi tạo đơn nhập")
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

        public List<DonNhapMD> GetAll()
        {
            var DonNhaps = _context.DonNhaps.Select(l => new DonNhapMD
            {
                IddonNhap = l.IddonNhap,    
                IdnhaCungCap=   l.IdnhaCungCap,
                Iduser = l.Iduser,
                NgayNhap = l.NgayNhap,
                TongTien = l.TongTien,
            }).ToList();
            return DonNhaps;
        }

        public JsonResult EditDonNhap(int iddonnhap, EditDonNhap edit)
        {
            var DonNhaps = _context.DonNhaps.SingleOrDefault(l => l.IddonNhap == iddonnhap);
            if (DonNhaps == null)
            {

                return new JsonResult("Khong tim thay id can chinh sua ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
            else
            {
                DonNhaps.IdnhaCungCap = edit.IdnhaCungCap;
                DonNhaps.NgayNhap = DateTime.Now;
                DonNhaps.TongTien = edit.TongTien;
                DonNhaps.Iduser = edit.Iduser;
                _context.SaveChanges();
                return new JsonResult(" Đã chinh sua ")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            
        }

        public JsonResult DeleteDonNhap(int idDonNhap)
        {
            var DonNhaps = _context.DonNhaps.SingleOrDefault(l => l.IddonNhap == idDonNhap);
            if (DonNhaps == null)
            {
                return new JsonResult("Không có ID đơn nhập  để xóa ")
                {
                    StatusCode = StatusCodes.Status404NotFound

                };
            }
            else
            {
                _context.DonNhaps.Remove(DonNhaps);
                _context.SaveChanges();

                return new JsonResult("Đã xóa")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            };

        }

        public DonNhapVM GetById(int iddonnhap)
        {
            var DonNhaps = _context.DonNhaps.SingleOrDefault(l => l.IddonNhap == iddonnhap);
            if(DonNhaps != null)
            {
                return new DonNhapVM
                {
                    IdnhaCungCap = DonNhaps.IdnhaCungCap,
                    Iduser = DonNhaps.Iduser,
                    NgayNhap = DonNhaps.NgayNhap,
                    TongTien = DonNhaps.TongTien,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
