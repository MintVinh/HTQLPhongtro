using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class NguoiNhanThongBao
{
    public int IdNn { get; set; }

    public int IdTb { get; set; }

    public int? IdKhach { get; set; }

    public int? IdPhong { get; set; }

    public bool IsRead { get; set; }

    public DateTime? NgayDoc { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual KhachHang? IdKhachNavigation { get; set; }

    public virtual Phong? IdPhongNavigation { get; set; }

    public virtual ThongBao IdTbNavigation { get; set; } = null!;
}
