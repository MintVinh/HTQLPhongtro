using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class TaiSanPhong
{
    public int IdTsPhong { get; set; }

    public int IdPhong { get; set; }

    public int IdTs { get; set; }

    public int SoLuong { get; set; }

    public string? TinhTrang { get; set; }

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Phong IdPhongNavigation { get; set; } = null!;

    public virtual TaiSan IdTsNavigation { get; set; } = null!;
}
