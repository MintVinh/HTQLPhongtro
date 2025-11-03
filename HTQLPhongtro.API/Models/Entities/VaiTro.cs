using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class VaiTro
{
    public int IdVt { get; set; }

    public string TenVt { get; set; } = null!;

    public string? MoTa { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
