using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class DatCoc
{
    public int IdCoc { get; set; }

    public int IdPhong { get; set; }

    public int IdKhach { get; set; }

    public decimal SoTien { get; set; }

    public DateOnly NgayCoc { get; set; }

    public DateOnly HanCoc { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual KhachHang IdKhachNavigation { get; set; } = null!;

    public virtual Phong IdPhongNavigation { get; set; } = null!;
}
