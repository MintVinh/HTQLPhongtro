using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class ChuTro
{
    public int IdChu { get; set; }

    public int IdTk { get; set; }

    public string HoTen { get; set; } = null!;

    public string? Cccd { get; set; }

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? DiaChi { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual TaiKhoan IdTkNavigation { get; set; } = null!;

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();

    public virtual ICollection<ThongBao> ThongBaos { get; set; } = new List<ThongBao>();
}
