using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TNN.Data;

public partial class CuaHangDienLanhContext : DbContext
{
    public CuaHangDienLanhContext()
    {
    }

    public CuaHangDienLanhContext(DbContextOptions<CuaHangDienLanhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietDonNhap> ChiTietDonNhaps { get; set; }

    public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<DonNhap> DonNhaps { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<Hang> Hangs { get; set; }

    public virtual DbSet<HinhAnhUser> HinhAnhUsers { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhoHang> KhoHangs { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TinhTrangSp> TinhTrangSps { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GE_G5\\SQLEXPRESS;Initial Catalog=CuaHangDienLanh;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietDonNhap>(entity =>
        {
            entity.HasKey(e => e.IdchiTietDonNhap);

            entity.ToTable("ChiTietDonNhap");

            entity.Property(e => e.IdchiTietDonNhap).HasColumnName("IDChiTietDonNhap");
            entity.Property(e => e.IddonNhap).HasColumnName("IDDonNhap");
            entity.Property(e => e.IdsanPham).HasColumnName("IDSanPham");

            entity.HasOne(d => d.IddonNhapNavigation).WithMany(p => p.ChiTietDonNhaps)
                .HasForeignKey(d => d.IddonNhap)
                .HasConstraintName("FK_ChiTietDonNhap_DonNhap");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany(p => p.ChiTietDonNhaps)
                .HasForeignKey(d => d.IdsanPham)
                .HasConstraintName("FK_ChiTietDonNhap_SanPham");
        });

        modelBuilder.Entity<ChiTietGioHang>(entity =>
        {
            entity.HasKey(e => e.IdchiTietGioHang).HasName("PK_CartItems");

            entity.ToTable("ChiTietGioHang");

            entity.Property(e => e.IdchiTietGioHang).HasColumnName("IDChiTietGioHang");
            entity.Property(e => e.IdgioHang).HasColumnName("IDGioHang");
            entity.Property(e => e.IdsanPham).HasColumnName("IDSanPham");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdgioHangNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.IdgioHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietGioHang_GioHang");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.IdsanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietGioHang_SanPham");
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => e.IdchiTietDonHang).HasName("PK_OrderDetails");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.IdchiTietDonHang).HasColumnName("IDChiTietDonHang");
            entity.Property(e => e.IddonHang).HasColumnName("IDDonHang");
            entity.Property(e => e.IdsanPham).HasColumnName("IDSanPham");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IddonHangNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IddonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietDonHang_DonHang");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.IdsanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDon_SanPham");
        });

        modelBuilder.Entity<DonNhap>(entity =>
        {
            entity.HasKey(e => e.IddonNhap);

            entity.ToTable("DonNhap");

            entity.Property(e => e.IddonNhap).HasColumnName("IDDonNhap");
            entity.Property(e => e.IdnhaCungCap).HasColumnName("IDNhaCungCap");
            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");

            entity.HasOne(d => d.IdnhaCungCapNavigation).WithMany(p => p.DonNhaps)
                .HasForeignKey(d => d.IdnhaCungCap)
                .HasConstraintName("FK_DonNhap_NhaCungCap");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.DonNhaps)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK_DonNhap_User");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.IdgioHang).HasName("PK_Cart");

            entity.ToTable("GioHang");

            entity.Property(e => e.IdgioHang).HasColumnName("IDGioHang");
            entity.Property(e => e.IdkhachHang).HasColumnName("IDKhachHang");
            entity.Property(e => e.MaGioHang)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdkhachHangNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.IdkhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GioHang_User");
        });

        modelBuilder.Entity<Hang>(entity =>
        {
            entity.HasKey(e => e.Idhang);

            entity.ToTable("Hang");

            entity.Property(e => e.Idhang).HasColumnName("IDHang");
            entity.Property(e => e.TenHang).HasColumnType("text");
        });

        modelBuilder.Entity<HinhAnhUser>(entity =>
        {
            entity.HasKey(e => e.IdhinhAnh);

            entity.ToTable("HinhAnhUser");

            entity.Property(e => e.IdhinhAnh).HasColumnName("IDHinhAnh");
            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.UrlHinhAnh).HasColumnType("text");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.HinhAnhUsers)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK_HinhAnhUser_User");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.IddonHang).HasName("PK_Orders");

            entity.ToTable("HoaDon");

            entity.Property(e => e.IddonHang).HasColumnName("IDDonHang");
            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.MaDonHang)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NgayDatHang).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK_DonHang_User");
        });

        modelBuilder.Entity<KhoHang>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("KhoHang");

            entity.Property(e => e.IdsanPham).HasColumnName("IDSanPham");
            entity.Property(e => e.SltrongKho).HasColumnName("SLTrongKho");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany()
                .HasForeignKey(d => d.IdsanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KhoHang_SanPham");
        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.HasKey(e => e.IdloaiSp);

            entity.ToTable("LoaiSP");

            entity.Property(e => e.IdloaiSp).HasColumnName("IDLoaiSP");
            entity.Property(e => e.MaLoaiSp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MaLoaiSP");
            entity.Property(e => e.TenLoaiSp)
                .HasMaxLength(250)
                .HasColumnName("TenLoaiSP");
        });

        modelBuilder.Entity<LoaiTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Idloai);

            entity.ToTable("LoaiTaiKhoan");

            entity.Property(e => e.Idloai).HasColumnName("IDLoai");
            entity.Property(e => e.MaLoai)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenLoai).HasMaxLength(50);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.IdnhaCungCap);

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.IdnhaCungCap).HasColumnName("IDNhaCungCap");
            entity.Property(e => e.DiaChi).HasMaxLength(250);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenNhaCungCap).HasMaxLength(250);
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.IdsanPham);

            entity.ToTable("SanPham");

            entity.Property(e => e.IdsanPham).HasColumnName("IDSanPham");
            entity.Property(e => e.CongSuat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Idhang).HasColumnName("IDHang");
            entity.Property(e => e.IdloaiSp).HasColumnName("IDLoaiSP");
            entity.Property(e => e.MaSp)
                .HasMaxLength(50)
                .HasColumnName("MaSP");
            entity.Property(e => e.NamSx).HasColumnName("NamSX");
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.IdhangNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.Idhang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_Hang");

            entity.HasOne(d => d.IdloaiSpNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.IdloaiSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SanPham_LoaiSP");
        });

        modelBuilder.Entity<TinhTrangSp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TinhTrangSP");

            entity.Property(e => e.IdsanPham).HasColumnName("IDSanPham");
            entity.Property(e => e.TinhTrang)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("0: Cũ 1: Mới");

            entity.HasOne(d => d.IdsanPhamNavigation).WithMany()
                .HasForeignKey(d => d.IdsanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TinhTrangSP_SanPham");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK_Customers");

            entity.ToTable("User");

            entity.Property(e => e.Iduser).HasColumnName("IDUser");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasComment("0:Nam 1:Nu");
            entity.Property(e => e.Ho).HasMaxLength(50);
            entity.Property(e => e.Idloai).HasColumnName("IDLoai");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.NgaySua).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(50);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdloaiNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Idloai)
                .HasConstraintName("FK_User_LoaiTaiKhoan");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
