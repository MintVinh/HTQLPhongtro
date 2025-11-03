using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class Phong
{
    public int IdPhong { get; set; }

    public int IdChu { get; set; }

    public int IdLoai { get; set; }

    public string TenPhong { get; set; } = null!;

    public int Tang { get; set; }

    public double DienTich { get; set; }

    public decimal GiaThue { get; set; }

    public decimal? TienDien { get; set; }

    public decimal? TienNuoc { get; set; }

    public decimal? TienMang { get; set; }

    public decimal? TienRac { get; set; }

    public decimal? TienGuiXe { get; set; }

    public int SoNguoiToiDa { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? MoTa { get; set; }

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ChiSoDienNuoc> ChiSoDienNuocs { get; set; } = new List<ChiSoDienNuoc>();

    public virtual ICollection<DatCoc> DatCocs { get; set; } = new List<DatCoc>();

    public virtual ICollection<HinhAnhPhong> HinhAnhPhongs { get; set; } = new List<HinhAnhPhong>();

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual ChuTro IdChuNavigation { get; set; } = null!;

    public virtual LoaiPhong IdLoaiNavigation { get; set; } = null!;

    public virtual ICollection<NguoiNhanThongBao> NguoiNhanThongBaos { get; set; } = new List<NguoiNhanThongBao>();

    public virtual ICollection<TaiSanPhong> TaiSanPhongs { get; set; } = new List<TaiSanPhong>();

    public virtual ICollection<YeuCauSuaChua> YeuCauSuaChuas { get; set; } = new List<YeuCauSuaChua>();
}
