using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class NguoiOcung
{
    public int IdNguoiO { get; set; }

    public int IdHd { get; set; }

    public string HoTen { get; set; } = null!;

    public string Cccd { get; set; } = null!;

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? QuanHe { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual HopDong IdHdNavigation { get; set; } = null!;
}
