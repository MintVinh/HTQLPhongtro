using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class HinhAnhYeuCau
{
    public int IdHa { get; set; }

    public int IdYc { get; set; }

    public string UrlHinhAnh { get; set; } = null!;

    public string? MoTa { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual YeuCauSuaChua IdYcNavigation { get; set; } = null!;
}
