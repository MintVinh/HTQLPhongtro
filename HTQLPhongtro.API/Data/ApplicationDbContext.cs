using System;
using System.Collections.Generic;
using HTQLPhongtro.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HTQLPhongtro.API.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BanGiaoPhong> BanGiaoPhongs { get; set; }

    public virtual DbSet<BangGium> BangGia { get; set; }

    public virtual DbSet<ChiSoDienNuoc> ChiSoDienNuocs { get; set; }

    public virtual DbSet<ChuTro> ChuTros { get; set; }

    public virtual DbSet<DatCoc> DatCocs { get; set; }

    public virtual DbSet<HinhAnhPhong> HinhAnhPhongs { get; set; }

    public virtual DbSet<HinhAnhYeuCau> HinhAnhYeuCaus { get; set; }

    public virtual DbSet<HoaDonThue> HoaDonThues { get; set; }

    public virtual DbSet<HoanCoc> HoanCocs { get; set; }

    public virtual DbSet<HopDong> HopDongs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<KiemTraPhong> KiemTraPhongs { get; set; }

    public virtual DbSet<LichSuHeThong> LichSuHeThongs { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<NguoiNhanThongBao> NguoiNhanThongBaos { get; set; }

    public virtual DbSet<NguoiOcung> NguoiOcungs { get; set; }

    public virtual DbSet<PhieuPhat> PhieuPhats { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<QuyDinhPhat> QuyDinhPhats { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TaiSan> TaiSans { get; set; }

    public virtual DbSet<TaiSanPhong> TaiSanPhongs { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    public virtual DbSet<ThongBao> ThongBaos { get; set; }

    public virtual DbSet<TraPhong> TraPhongs { get; set; }

    public virtual DbSet<VaiTro> VaiTros { get; set; }

    public virtual DbSet<VwCongNo> VwCongNos { get; set; }

    public virtual DbSet<VwDoanhThuThang> VwDoanhThuThangs { get; set; }

    public virtual DbSet<VwPhongInfo> VwPhongInfos { get; set; }

    public virtual DbSet<YeuCauSuaChua> YeuCauSuaChuas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MINTZINH\\SQLEXPRESS;Database=HTQLPhongtro_claude;Integrated Security=True;TrustServerCertificate=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BanGiaoPhong>(entity =>
        {
            entity.HasKey(e => e.IdBgp);

            entity.ToTable("BanGiaoPhong");

            entity.HasIndex(e => e.IdHd, "UK_BanGiaoPhong_IdHd").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FileBienBan).HasMaxLength(500);
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.NguoiBanGiao).HasMaxLength(100);
            entity.Property(e => e.NguoiNhan).HasMaxLength(100);
            entity.Property(e => e.TinhTrangPhong).HasMaxLength(50);

            entity.HasOne(d => d.IdHdNavigation).WithOne(p => p.BanGiaoPhong)
                .HasForeignKey<BanGiaoPhong>(d => d.IdHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BanGiaoPhong_HopDong");
        });

        modelBuilder.Entity<BangGium>(entity =>
        {
            entity.HasKey(e => e.IdBg);

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DonVi).HasMaxLength(20);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LoaiDichVu).HasMaxLength(50);
        });

        modelBuilder.Entity<ChiSoDienNuoc>(entity =>
        {
            entity.HasKey(e => e.IdCs);

            entity.ToTable("ChiSoDienNuoc");

            entity.HasIndex(e => e.IdPhong, "IX_ChiSoDienNuoc_IdPhong");

            entity.HasIndex(e => new { e.Thang, e.Nam }, "IX_ChiSoDienNuoc_ThangNam");

            entity.HasIndex(e => new { e.IdPhong, e.Thang, e.Nam }, "UK_ChiSoDienNuoc").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(500);

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.ChiSoDienNuocs)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiSoDienNuoc_Phong");
        });

        modelBuilder.Entity<ChuTro>(entity =>
        {
            entity.HasKey(e => e.IdChu);

            entity.ToTable("ChuTro");

            entity.HasIndex(e => e.Cccd, "UK_ChuTro_Cccd").IsUnique();

            entity.HasIndex(e => e.Sdt, "UK_ChuTro_Sdt").IsUnique();

            entity.Property(e => e.Cccd).HasMaxLength(12);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Sdt).HasMaxLength(15);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdTkNavigation).WithMany(p => p.ChuTros)
                .HasForeignKey(d => d.IdTk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChuTro_TaiKhoan");
        });

        modelBuilder.Entity<DatCoc>(entity =>
        {
            entity.HasKey(e => e.IdCoc);

            entity.ToTable("DatCoc");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdKhachNavigation).WithMany(p => p.DatCocs)
                .HasForeignKey(d => d.IdKhach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DatCoc_KhachHang");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.DatCocs)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DatCoc_Phong");
        });

        modelBuilder.Entity<HinhAnhPhong>(entity =>
        {
            entity.HasKey(e => e.IdHinhAnh);

            entity.ToTable("HinhAnhPhong");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MoTa).HasMaxLength(200);
            entity.Property(e => e.UrlHinhAnh).HasMaxLength(500);

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.HinhAnhPhongs)
                .HasForeignKey(d => d.IdPhong)
                .HasConstraintName("FK_HinhAnhPhong_Phong");
        });

        modelBuilder.Entity<HinhAnhYeuCau>(entity =>
        {
            entity.HasKey(e => e.IdHa);

            entity.ToTable("HinhAnhYeuCau");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MoTa).HasMaxLength(200);
            entity.Property(e => e.UrlHinhAnh).HasMaxLength(500);

            entity.HasOne(d => d.IdYcNavigation).WithMany(p => p.HinhAnhYeuCaus)
                .HasForeignKey(d => d.IdYc)
                .HasConstraintName("FK_HinhAnhYeuCau_YeuCauSuaChua");
        });

        modelBuilder.Entity<HoaDonThue>(entity =>
        {
            entity.HasKey(e => e.IdHdThue);

            entity.ToTable("HoaDonThue");

            entity.HasIndex(e => e.IdHd, "IX_HoaDonThue_IdHd");

            entity.HasIndex(e => new { e.Thang, e.Nam }, "IX_HoaDonThue_ThangNam");

            entity.HasIndex(e => e.TrangThai, "IX_HoaDonThue_TrangThai");

            entity.HasIndex(e => e.MaHoaDon, "UK_HoaDonThue_MaHoaDon").IsUnique();

            entity.HasIndex(e => new { e.IdHd, e.Thang, e.Nam }, "UK_HoaDonThue_ThangNam").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.GiamGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaHoaDon).HasMaxLength(50);
            entity.Property(e => e.TienDien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienGuiXe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienMang).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienNuoc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienPhat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienPhong).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienRac).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Unpaid");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdCsNavigation).WithMany(p => p.HoaDonThues)
                .HasForeignKey(d => d.IdCs)
                .HasConstraintName("FK_HoaDonThue_ChiSoDienNuoc");

            entity.HasOne(d => d.IdHdNavigation).WithMany(p => p.HoaDonThues)
                .HasForeignKey(d => d.IdHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDonThue_HopDong");
        });

        modelBuilder.Entity<HoanCoc>(entity =>
        {
            entity.HasKey(e => e.IdHoan);

            entity.ToTable("HoanCoc");

            entity.HasIndex(e => e.IdTra, "UK_HoanCoc_IdTra").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.MaGiaoDich).HasMaxLength(100);
            entity.Property(e => e.PhuongThucHoan).HasMaxLength(50);
            entity.Property(e => e.SoTienHoan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienCocBanDau).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienDienNuocConLai).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienKhac).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienPhatConLai).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienSuaChua).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdKtNavigation).WithMany(p => p.HoanCocs)
                .HasForeignKey(d => d.IdKt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoanCoc_KiemTraPhong");

            entity.HasOne(d => d.IdTraNavigation).WithOne(p => p.HoanCoc)
                .HasForeignKey<HoanCoc>(d => d.IdTra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoanCoc_TraPhong");
        });

        modelBuilder.Entity<HopDong>(entity =>
        {
            entity.HasKey(e => e.IdHd);

            entity.ToTable("HopDong");

            entity.HasIndex(e => e.IdKhach, "IX_HopDong_IdKhach");

            entity.HasIndex(e => e.IdPhong, "IX_HopDong_IdPhong");

            entity.HasIndex(e => e.TrangThai, "IX_HopDong_TrangThai");

            entity.HasIndex(e => e.MaHopDong, "UK_HopDong_MaHopDong").IsUnique();

            entity.Property(e => e.ChuKyThanhToan).HasDefaultValue(1);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FileDinhKem).HasMaxLength(500);
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.GiaThue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaHopDong).HasMaxLength(50);
            entity.Property(e => e.NgayThanhToan).HasDefaultValue(5);
            entity.Property(e => e.TienCoc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdCocNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.IdCoc)
                .HasConstraintName("FK_HopDong_DatCoc");

            entity.HasOne(d => d.IdKhachNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.IdKhach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HopDong_KhachHang");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HopDong_Phong");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.IdKhach);

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Cccd, "UK_KhachHang_Cccd").IsUnique();

            entity.HasIndex(e => e.Sdt, "UK_KhachHang_Sdt").IsUnique();

            entity.Property(e => e.Cccd).HasMaxLength(12);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DiaChi).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.NgheNghiep).HasMaxLength(100);
            entity.Property(e => e.Sdt).HasMaxLength(15);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdTkNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.IdTk)
                .HasConstraintName("FK_KhachHang_TaiKhoan");
        });

        modelBuilder.Entity<KiemTraPhong>(entity =>
        {
            entity.HasKey(e => e.IdKt);

            entity.ToTable("KiemTraPhong");

            entity.HasIndex(e => e.IdTra, "UK_KiemTraPhong_IdTra").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FileBienBan).HasMaxLength(500);
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.TinhTrangChung).HasMaxLength(50);
            entity.Property(e => e.TinhTrangCuaSoKhoa).HasMaxLength(500);
            entity.Property(e => e.TinhTrangDienNuoc).HasMaxLength(500);
            entity.Property(e => e.TinhTrangTuongVaSan).HasMaxLength(500);
            entity.Property(e => e.TinhTrangVeSinh).HasMaxLength(500);
            entity.Property(e => e.TongChiPhiSuaChua).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdTraNavigation).WithOne(p => p.KiemTraPhong)
                .HasForeignKey<KiemTraPhong>(d => d.IdTra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KiemTraPhong_TraPhong");
        });

        modelBuilder.Entity<LichSuHeThong>(entity =>
        {
            entity.HasKey(e => e.IdLs);

            entity.ToTable("LichSuHeThong");

            entity.HasIndex(e => e.IdTk, "IX_LichSuHeThong_IdTk");

            entity.HasIndex(e => e.ThoiGian, "IX_LichSuHeThong_ThoiGian");

            entity.Property(e => e.DoiTuong).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.HanhDong).HasMaxLength(100);
            entity.Property(e => e.IpAddress).HasMaxLength(50);
            entity.Property(e => e.ThoiGian)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdTkNavigation).WithMany(p => p.LichSuHeThongs)
                .HasForeignKey(d => d.IdTk)
                .HasConstraintName("FK_LichSuHeThong_TaiKhoan");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.IdLoai);

            entity.ToTable("LoaiPhong");

            entity.HasIndex(e => e.TenLoai, "UK_LoaiPhong_TenLoai").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GiaThueGocMax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GiaThueGocMin).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<NguoiNhanThongBao>(entity =>
        {
            entity.HasKey(e => e.IdNn);

            entity.ToTable("NguoiNhanThongBao");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayDoc).HasColumnType("datetime");

            entity.HasOne(d => d.IdKhachNavigation).WithMany(p => p.NguoiNhanThongBaos)
                .HasForeignKey(d => d.IdKhach)
                .HasConstraintName("FK_NguoiNhanThongBao_KhachHang");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.NguoiNhanThongBaos)
                .HasForeignKey(d => d.IdPhong)
                .HasConstraintName("FK_NguoiNhanThongBao_Phong");

            entity.HasOne(d => d.IdTbNavigation).WithMany(p => p.NguoiNhanThongBaos)
                .HasForeignKey(d => d.IdTb)
                .HasConstraintName("FK_NguoiNhanThongBao_ThongBao");
        });

        modelBuilder.Entity<NguoiOcung>(entity =>
        {
            entity.HasKey(e => e.IdNguoiO);

            entity.ToTable("NguoiOCung");

            entity.Property(e => e.Cccd).HasMaxLength(12);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.QuanHe).HasMaxLength(50);
            entity.Property(e => e.Sdt).HasMaxLength(15);

            entity.HasOne(d => d.IdHdNavigation).WithMany(p => p.NguoiOcungs)
                .HasForeignKey(d => d.IdHd)
                .HasConstraintName("FK_NguoiOCung_HopDong");
        });

        modelBuilder.Entity<PhieuPhat>(entity =>
        {
            entity.HasKey(e => e.IdPhat);

            entity.ToTable("PhieuPhat");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.LyDo).HasMaxLength(500);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Unpaid");

            entity.HasOne(d => d.IdHdNavigation).WithMany(p => p.PhieuPhats)
                .HasForeignKey(d => d.IdHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhieuPhat_HopDong");

            entity.HasOne(d => d.IdQdpNavigation).WithMany(p => p.PhieuPhats)
                .HasForeignKey(d => d.IdQdp)
                .HasConstraintName("FK_PhieuPhat_QuyDinhPhat");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.IdPhong);

            entity.ToTable("Phong");

            entity.HasIndex(e => e.IdChu, "IX_Phong_IdChu");

            entity.HasIndex(e => e.TrangThai, "IX_Phong_TrangThai");

            entity.HasIndex(e => new { e.IdChu, e.TenPhong }, "UK_Phong_TenPhong").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.GiaThue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MoTa).HasMaxLength(1000);
            entity.Property(e => e.SoNguoiToiDa).HasDefaultValue(2);
            entity.Property(e => e.Tang).HasDefaultValue(1);
            entity.Property(e => e.TenPhong).HasMaxLength(50);
            entity.Property(e => e.TienDien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienGuiXe).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienMang).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienNuoc).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TienRac).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Available");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdChuNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.IdChu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_ChuTro");

            entity.HasOne(d => d.IdLoaiNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.IdLoai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phong_LoaiPhong");
        });

        modelBuilder.Entity<QuyDinhPhat>(entity =>
        {
            entity.HasKey(e => e.IdQdp);

            entity.ToTable("QuyDinhPhat");

            entity.HasIndex(e => e.LoaiViPham, "UK_QuyDinhPhat_LoaiViPham").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DonVi).HasMaxLength(20);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LoaiViPham).HasMaxLength(100);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.MucPhat).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.IdTk);

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.Email, "UK_TaiKhoan_Email").IsUnique();

            entity.HasIndex(e => e.Username, "UK_TaiKhoan_Username").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Active");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.IdVtNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdVt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaiKhoan_VaiTro");
        });

        modelBuilder.Entity<TaiSan>(entity =>
        {
            entity.HasKey(e => e.IdTs);

            entity.ToTable("TaiSan");

            entity.HasIndex(e => e.TenTs, "UK_TaiSan_TenTs").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DonViTinh).HasMaxLength(50);
            entity.Property(e => e.GiaTri).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenTs).HasMaxLength(100);
        });

        modelBuilder.Entity<TaiSanPhong>(entity =>
        {
            entity.HasKey(e => e.IdTsPhong);

            entity.ToTable("TaiSanPhong");

            entity.HasIndex(e => new { e.IdPhong, e.IdTs }, "UK_TaiSanPhong").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.SoLuong).HasDefaultValue(1);
            entity.Property(e => e.TinhTrang).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.TaiSanPhongs)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaiSanPhong_Phong");

            entity.HasOne(d => d.IdTsNavigation).WithMany(p => p.TaiSanPhongs)
                .HasForeignKey(d => d.IdTs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaiSanPhong_TaiSan");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.IdTt);

            entity.ToTable("ThanhToan");

            entity.HasIndex(e => e.IdHdThue, "IX_ThanhToan_IdHdThue");

            entity.HasIndex(e => e.NgayTt, "IX_ThanhToan_NgayTt");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.MaGiaoDich).HasMaxLength(100);
            entity.Property(e => e.PhuongThuc).HasMaxLength(50);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdHdThueNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.IdHdThue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThanhToan_HoaDonThue");
        });

        modelBuilder.Entity<ThongBao>(entity =>
        {
            entity.HasKey(e => e.IdTb);

            entity.ToTable("ThongBao");

            entity.HasIndex(e => e.NgayGui, "IX_ThongBao_NgayGui");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LoaiTb).HasMaxLength(50);
            entity.Property(e => e.MucDo)
                .HasMaxLength(20)
                .HasDefaultValue("Normal");
            entity.Property(e => e.NgayGui)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayHetHan).HasColumnType("datetime");
            entity.Property(e => e.TieuDe).HasMaxLength(200);

            entity.HasOne(d => d.IdChuNavigation).WithMany(p => p.ThongBaos)
                .HasForeignKey(d => d.IdChu)
                .HasConstraintName("FK_ThongBao_ChuTro");
        });

        modelBuilder.Entity<TraPhong>(entity =>
        {
            entity.HasKey(e => e.IdTra);

            entity.ToTable("TraPhong");

            entity.HasIndex(e => e.IdHd, "UK_TraPhong_IdHd").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.LyDoTra).HasMaxLength(500);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdHdNavigation).WithOne(p => p.TraPhong)
                .HasForeignKey<TraPhong>(d => d.IdHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TraPhong_HopDong");
        });

        modelBuilder.Entity<VaiTro>(entity =>
        {
            entity.HasKey(e => e.IdVt);

            entity.ToTable("VaiTro");

            entity.HasIndex(e => e.TenVt, "UK_VaiTro_TenVt").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenVt).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwCongNo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_CongNo");

            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt).HasMaxLength(15);
            entity.Property(e => e.SoHoaDonChuaTt).HasColumnName("SoHoaDonChuaTT");
            entity.Property(e => e.TenPhong).HasMaxLength(50);
            entity.Property(e => e.TongCongNo).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<VwDoanhThuThang>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DoanhThuThang");

            entity.Property(e => e.ChuaThanhToan).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.DaThanhToan).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TongDoanhThu).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TongTienDien).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TongTienNuoc).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.TongTienPhong).HasColumnType("decimal(38, 2)");
        });

        modelBuilder.Entity<VwPhongInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_PhongInfo");

            entity.Property(e => e.ChuTro).HasMaxLength(100);
            entity.Property(e => e.GiaThue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.KhachThueHienTai).HasMaxLength(100);
            entity.Property(e => e.LoaiPhong).HasMaxLength(100);
            entity.Property(e => e.SdtChuTro).HasMaxLength(15);
            entity.Property(e => e.SdtKhachThue).HasMaxLength(15);
            entity.Property(e => e.TenPhong).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(20);
        });

        modelBuilder.Entity<YeuCauSuaChua>(entity =>
        {
            entity.HasKey(e => e.IdYc);

            entity.ToTable("YeuCauSuaChua");

            entity.HasIndex(e => e.IdPhong, "IX_YeuCauSuaChua_IdPhong");

            entity.HasIndex(e => e.TrangThai, "IX_YeuCauSuaChua_TrangThai");

            entity.Property(e => e.ChiPhi).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GhiChu).HasMaxLength(1000);
            entity.Property(e => e.MucDo)
                .HasMaxLength(20)
                .HasDefaultValue("Normal");
            entity.Property(e => e.NgayHoanThanh).HasColumnType("datetime");
            entity.Property(e => e.NgayXuLy).HasColumnType("datetime");
            entity.Property(e => e.NgayYeuCau)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TieuDe).HasMaxLength(200);
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdKhachNavigation).WithMany(p => p.YeuCauSuaChuas)
                .HasForeignKey(d => d.IdKhach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YeuCauSuaChua_KhachHang");

            entity.HasOne(d => d.IdPhongNavigation).WithMany(p => p.YeuCauSuaChuas)
                .HasForeignKey(d => d.IdPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_YeuCauSuaChua_Phong");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
