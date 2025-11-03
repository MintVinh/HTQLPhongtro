using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class HoaDonThue
{
    public int IdHdThue { get; set; }

    public int IdHd { get; set; }

    public int? IdCs { get; set; }

    public string MaHoaDon { get; set; } = null!;

    public int Thang { get; set; }

    public int Nam { get; set; }

    public decimal TienPhong { get; set; }

    public decimal TienDien { get; set; }

    public decimal TienNuoc { get; set; }

    public decimal TienMang { get; set; }

    public decimal TienRac { get; set; }

    public decimal TienGuiXe { get; set; }

    public decimal TienPhat { get; set; }

    public decimal GiamGia { get; set; }

    public decimal TongTien { get; set; }

    public DateOnly HanThanhToan { get; set; }

    public DateOnly? NgayThanhToan { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual ChiSoDienNuoc? IdCsNavigation { get; set; }

    public virtual HopDong IdHdNavigation { get; set; } = null!;

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
