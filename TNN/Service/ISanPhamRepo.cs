using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TNN.Data;
using TNN.DataReader;
using TNN.ViewModel;

namespace TNN.Service
{
    public interface ISanPhamRepo
    {
        List<SanPhamMD> GetAll();
        SanPhamMD GetByID(int idSanPham);
        JsonResult AddSanPham(AddSP add);
        IActionResult DeleteByID(int IdSanPham);
        JsonResult EditSanPham(EditSanPham edit);
    }
    public class SanPhamRepo : ISanPhamRepo
    {
        private readonly DataDapper _data;
        private readonly CuaHangDienLanhContext _context;
        public SanPhamRepo(DataDapper dapper, CuaHangDienLanhContext context)
        {
            _data = dapper;
            _context = context;
        }

        public List<SanPhamMD> GetAll()
        {
            var sanpham = _context.SanPhams.Select(u => new SanPhamMD
            {
                IdsanPham = u.IdsanPham,
                MaSp = u.MaSp,
                TenSp = u.TenSp,
                IdloaiSp = u.IdloaiSp,
                Idhang = u.Idhang,
                Gia = u.Gia,
                CongSuat = u.CongSuat,
                GhiChu = u.GhiChu

            }).ToList();
            return sanpham;
        }


        public SanPhamMD GetByID(int idSanPham)
        {
            var check = _context.SanPhams.SingleOrDefault(u => u.IdsanPham == idSanPham);

            if (check != null)
            {
                return new SanPhamMD
                {
                    IdsanPham = check.IdsanPham,
                    MaSp = check.MaSp,
                    TenSp = check.TenSp,
                    IdloaiSp = check.IdloaiSp,
                    Idhang = check.Idhang,
                    Gia = check.Gia,
                    CongSuat = check.CongSuat,
                    GhiChu = check.GhiChu,
                    TinhTrang = check.TinhTrang,
                    SoLuong = check.SoLuong,
                };

            }
            else
            {
                return null;
            }

        }

        public IActionResult DeleteByID(int IdSanPham)
        {
            var check = _context.SanPhams.FirstOrDefault(d => d.IdsanPham == IdSanPham);
            if (check != null)
            {
                _context.SanPhams.Remove(check);
                _context.SaveChanges();
                return new JsonResult("Xoa Thanh Cong")
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            else
            {
                return new JsonResult("Khong tim thay ")
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
            }
        }


        public JsonResult EditSanPham(EditSanPham edit)
        {
            var para = new
            {
                IDSanPham = edit.IdsanPham,
                MaSp = edit.MaSp,
                TenSp = edit.TenSp,
                IdloaiSp = edit.IdloaiSp,
                Idhang = edit.Idhang,
                Gia = edit.Gia,
                NamSx = edit.NamSx,
                CongSuat = edit.CongSuat,
                GhiChu = edit.GhiChu,
                TinhTrang = edit.TinhTrang,
                SLTrongKho = edit.SoLuong,
            };
            string sql = "proc_editSanPham";
            try
            {
                var affectedRows = _data.Execute(sql, para);
                if (affectedRows == 1)
                {
                    return new JsonResult("Đã Sửa")
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                else
                {
                    return new JsonResult("Không thể sửa sản phẩm")
                    {
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }

        public JsonResult AddSanPham(AddSP add)
        {
            var para = new
            {
                MaSp = add.MaSp,
                TenSp = add.TenSp,
                IdloaiSp = add.IdloaiSp,
                Idhang = add.Idhang,
                Gia = add.Gia,
                NamSx = add.NamSx,
                CongSuat = add.CongSuat,
                GhiChu = add.GhiChu,
                TinhTrang = add.TinhTrang,
                SLTrongKho = add.SoLuong,
            };
            string sql = "proc_AddSanPham";
            try
            {
                var affectedRows = _data.Execute(sql, para);
                if (affectedRows >01)
                {
                    return new JsonResult("Đã Thêm")
                    {
                        StatusCode = StatusCodes.Status200OK
                    };
                }
                else
                {
                    return new JsonResult("Không thể tạo sản phẩm")
                    {
                        StatusCode = StatusCodes.Status404NotFound
                    };
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
            }
        }
    }
}
