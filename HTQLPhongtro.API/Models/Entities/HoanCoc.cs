using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class HoanCoc
{
    public int IdHoan { get; set; }

    public int IdTra { get; set; }

    public int IdKt { get; set; }

    public decimal TienCocBanDau { get; set; }

    public decimal TienDienNuocConLai { get; set; }

    public decimal TienPhatConLai { get; set; }

    public decimal TienSuaChua { get; set; }

    public decimal TienKhac { get; set; }

    public decimal SoTienHoan { get; set; }

    public DateOnly? NgayHoan { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? PhuongThucHoan { get; set; }

    public string? MaGiaoDich { get; set; }

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual KiemTraPhong IdKtNavigation { get; set; } = null!;

    public virtual TraPhong IdTraNavigation { get; set; } = null!;
}
