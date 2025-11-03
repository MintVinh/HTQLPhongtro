using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class TraPhong
{
    public int IdTra { get; set; }

    public int IdHd { get; set; }

    public DateOnly NgayYeuCau { get; set; }

    public DateOnly? NgayTraThucTe { get; set; }

    public string? LyDoTra { get; set; }

    public double? ChiSoDienCuoi { get; set; }

    public double? ChiSoNuocCuoi { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual HoanCoc? HoanCoc { get; set; }

    public virtual HopDong IdHdNavigation { get; set; } = null!;

    public virtual KiemTraPhong? KiemTraPhong { get; set; }
}
