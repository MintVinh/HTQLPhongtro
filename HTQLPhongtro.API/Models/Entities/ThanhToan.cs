using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class ThanhToan
{
    public int IdTt { get; set; }

    public int IdHdThue { get; set; }

    public DateOnly NgayTt { get; set; }

    public decimal SoTien { get; set; }

    public string PhuongThuc { get; set; } = null!;

    public string? MaGiaoDich { get; set; }

    public int? NguoiThu { get; set; }

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual HoaDonThue IdHdThueNavigation { get; set; } = null!;
}
