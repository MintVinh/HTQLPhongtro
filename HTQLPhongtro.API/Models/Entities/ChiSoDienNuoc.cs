using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class ChiSoDienNuoc
{
    public int IdCs { get; set; }

    public int IdPhong { get; set; }

    public int Thang { get; set; }

    public int Nam { get; set; }

    public double ChiSoDienCu { get; set; }

    public double ChiSoDienMoi { get; set; }

    public double TieuThuDien { get; set; }

    public double ChiSoNuocCu { get; set; }

    public double ChiSoNuocMoi { get; set; }

    public double TieuThuNuoc { get; set; }

    public DateOnly NgayGhi { get; set; }

    public int? NguoiGhi { get; set; }

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<HoaDonThue> HoaDonThues { get; set; } = new List<HoaDonThue>();

    public virtual Phong IdPhongNavigation { get; set; } = null!;
}
