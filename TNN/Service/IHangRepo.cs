using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface IHangRepo
    {
        JsonResult Addhang( AddHang addHang);
        JsonResult Delete(int idhang);
        JsonResult Edit(int idhang, AddHang addHang);
        List<HangMD> GetAll();
        HangVM GetByID(int idhang);
    }

    public class HangRepo : IHangRepo
    {
        private readonly CuaHangDienLanhContext _context;
        public HangRepo (CuaHangDienLanhContext context)
        {
            _context = context;
        }

        public JsonResult Addhang( AddHang addHang)
        {
            try
            {
                var hang = new Hang
                {
                    TenHang = addHang.TenHang,
                };
                _context.Hangs.Add(hang);
                _context.SaveChanges();
                return new JsonResult("Đã khởi tạo hãng ")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }

            catch (Exception ex)
            {
                {
                    return new JsonResult("Đã tồn tại ")
                    {
                        StatusCode = StatusCodes.Status500InternalServerError
                    };
                }
            }
        }

        public JsonResult Delete(int idhang)
        {
            var check = _context.Hangs.FirstOrDefault(c => c.Idhang == idhang);
            if (check != null)
            {
                _context.Hangs.Remove(check);
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

        public JsonResult Edit(int idhang, AddHang addHang)
        {
            var check = _context.Hangs.FirstOrDefault(c=> c.Idhang == idhang);
            if (check != null)
            {
                check.TenHang = addHang.TenHang;   
                _context.SaveChanges();
                return new JsonResult("Đã sửa")
                {
                    StatusCode = StatusCodes.Status200OK
                };

            }
            else
            {
                return new JsonResult("Không có hãng cần sửa")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }

        public List<HangMD> GetAll()
        {
            var hangs = _context.Hangs.Select(h => new HangMD
            {
                Idhang = h.Idhang,
                TenHang = h.TenHang,
            }).ToList();
            return hangs;
        }

        public HangVM GetByID(int idhang)
        {
            var check = _context.Hangs.FirstOrDefault(c => c.Idhang == idhang);
            if (check != null)
            {
                return new HangVM
                {
                    TenHang = check.TenHang,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
