using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class LichSuHeThong
{
    public int IdLs { get; set; }

    public int? IdTk { get; set; }

    public string HanhDong { get; set; } = null!;

    public string DoiTuong { get; set; } = null!;

    public int? IdDoiTuong { get; set; }

    public string? DuLieuCu { get; set; }

    public string? DuLieuMoi { get; set; }

    public string? IpAddress { get; set; }

    public DateTime ThoiGian { get; set; }

    public string? GhiChu { get; set; }

    public virtual TaiKhoan? IdTkNavigation { get; set; }
}
