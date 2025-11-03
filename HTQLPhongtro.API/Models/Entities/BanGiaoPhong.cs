using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class BanGiaoPhong
{
    public int IdBgp { get; set; }

    public int IdHd { get; set; }

    public DateOnly NgayBanGiao { get; set; }

    public string TinhTrangPhong { get; set; } = null!;

    public double? ChiSoDienDau { get; set; }

    public double? ChiSoNuocDau { get; set; }

    public string? GhiChu { get; set; }

    public string? NguoiBanGiao { get; set; }

    public string? NguoiNhan { get; set; }

    public string? FileBienBan { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual HopDong IdHdNavigation { get; set; } = null!;
}
