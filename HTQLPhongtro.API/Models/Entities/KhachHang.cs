using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class KhachHang
{
    public int IdKhach { get; set; }

    public int? IdTk { get; set; }

    public string HoTen { get; set; } = null!;

    public string Cccd { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? NgheNghiep { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<DatCoc> DatCocs { get; set; } = new List<DatCoc>();

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual TaiKhoan? IdTkNavigation { get; set; }

    public virtual ICollection<NguoiNhanThongBao> NguoiNhanThongBaos { get; set; } = new List<NguoiNhanThongBao>();

    public virtual ICollection<YeuCauSuaChua> YeuCauSuaChuas { get; set; } = new List<YeuCauSuaChua>();
}
