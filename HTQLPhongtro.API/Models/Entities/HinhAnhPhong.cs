using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class HinhAnhPhong
{
    public int IdHinhAnh { get; set; }

    public int IdPhong { get; set; }

    public string UrlHinhAnh { get; set; } = null!;

    public string? MoTa { get; set; }

    public int ThuTu { get; set; }

    public bool IsMain { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Phong IdPhongNavigation { get; set; } = null!;
}
