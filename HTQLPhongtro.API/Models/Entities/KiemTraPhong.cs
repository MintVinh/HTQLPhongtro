using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class KiemTraPhong
{
    public int IdKt { get; set; }

    public int IdTra { get; set; }

    public string TinhTrangChung { get; set; } = null!;

    public string? TinhTrangTuongVaSan { get; set; }

    public string? TinhTrangDienNuoc { get; set; }

    public string? TinhTrangCuaSoKhoa { get; set; }

    public string? TinhTrangVeSinh { get; set; }

    public string? DanhSachHuHai { get; set; }

    public decimal TongChiPhiSuaChua { get; set; }

    public int? NguoiKiemTra { get; set; }

    public DateOnly NgayKiemTra { get; set; }

    public string? GhiChu { get; set; }

    public string? FileBienBan { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<HoanCoc> HoanCocs { get; set; } = new List<HoanCoc>();

    public virtual TraPhong IdTraNavigation { get; set; } = null!;
}
