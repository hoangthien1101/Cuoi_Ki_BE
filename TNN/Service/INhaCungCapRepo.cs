using Microsoft.AspNetCore.Mvc;
using TNN.Data;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface INhaCungCapRepo
    {
        List<NhaCungCapMD> GetAll();
        NhaCungCapMD GetByID(int id);
        IActionResult AddNhaCungCap(edit add);
        IActionResult EditNhaCungCap(edit edit);
        IActionResult Delete(int id);
    }
    public class NhaCungCapRepo : INhaCungCapRepo
    {
        private readonly CuaHangDienLanhContext _context;
        public NhaCungCapRepo(CuaHangDienLanhContext context)
        {
            _context = context;
        }




        public List<NhaCungCapMD> GetAll()
        {
            var nhacc = _context.NhaCungCaps.Select(u => new NhaCungCapMD
            {
                IdnhaCungCap = u.IdnhaCungCap,
                TenNhaCungCap = u.TenNhaCungCap,
                DiaChi = u.DiaChi,
                Email = u.Email,
                SoDienThoai = u.SoDienThoai,


            }).ToList();
            return nhacc;
        }

        public NhaCungCapMD GetByID(int id)
        {
            var check = _context.NhaCungCaps.SingleOrDefault(u => u.IdnhaCungCap == id);
            if (check == null)
            {

                return null;
            }
            else
            {
                return new NhaCungCapMD
                {
                    IdnhaCungCap = check.IdnhaCungCap,
                    TenNhaCungCap = check.TenNhaCungCap,
                    DiaChi = check.DiaChi,
                    Email = check.Email,
                    SoDienThoai = check.SoDienThoai
                };
            }

        }


        public IActionResult AddNhaCungCap(edit add)
        {
            var check = _context.NhaCungCaps.SingleOrDefault(a => a.IdnhaCungCap == add.IdnhaCungCap);
            if (check == null)
            {
                var nhacc = new NhaCungCap
                {

                    TenNhaCungCap = add.TenNhaCungCap,
                    DiaChi = add.DiaChi,
                    Email = add.Email,
                    SoDienThoai = add.SoDienThoai

                };
                _context.Add(nhacc);
                _context.SaveChanges();

                return new ObjectResult("Đã khởi tạo")
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

        public IActionResult EditNhaCungCap(edit edit)
        {
            var check = _context.NhaCungCaps.SingleOrDefault(u => u.IdnhaCungCap == edit.IdnhaCungCap);

            if (check == null)
            {
                return new JsonResult("khong ton tai")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            else
            {
                check.TenNhaCungCap = edit.TenNhaCungCap;
                check.DiaChi = edit.DiaChi;
                check.Email = edit.Email;
                check.SoDienThoai = edit.SoDienThoai;

                _context.SaveChanges();

                return new ObjectResult("Sua thanh cong")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }

        }


        public IActionResult Delete(int id)
        {
            var check = _context.NhaCungCaps.FirstOrDefault(u => u.IdnhaCungCap == id);

            if (check == null)
            {
                return new JsonResult("khong ton tai")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            else
            {
                _context.NhaCungCaps.Remove(check);
                _context.SaveChanges();

                return new ObjectResult("xoa thanh cong")
                {
                    StatusCode = StatusCodes.Status201Created
                };
            }

        }

    }
}
