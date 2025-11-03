using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class TaiSan
{
    public int IdTs { get; set; }

    public string TenTs { get; set; } = null!;

    public string? MoTa { get; set; }

    public string? DonViTinh { get; set; }

    public decimal? GiaTri { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<TaiSanPhong> TaiSanPhongs { get; set; } = new List<TaiSanPhong>();
}
