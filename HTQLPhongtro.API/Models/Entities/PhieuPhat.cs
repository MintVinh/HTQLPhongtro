using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class PhieuPhat
{
    public int IdPhat { get; set; }

    public int IdHd { get; set; }

    public int? IdQdp { get; set; }

    public string LyDo { get; set; } = null!;

    public decimal SoTien { get; set; }

    public DateOnly NgayPhat { get; set; }

    public string TrangThai { get; set; } = null!;

    public DateOnly? NgayThanhToan { get; set; }

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual HopDong IdHdNavigation { get; set; } = null!;

    public virtual QuyDinhPhat? IdQdpNavigation { get; set; }
}
