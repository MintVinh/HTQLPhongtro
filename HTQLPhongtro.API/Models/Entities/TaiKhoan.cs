using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class TaiKhoan
{
    public int IdTk { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int IdVt { get; set; }

    public string TrangThai { get; set; } = null!;

    public DateTime? LastLogin { get; set; }

    public int FailedLoginAttempts { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ChuTro> ChuTros { get; set; } = new List<ChuTro>();

    public virtual VaiTro IdVtNavigation { get; set; } = null!;

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<LichSuHeThong> LichSuHeThongs { get; set; } = new List<LichSuHeThong>();
}
