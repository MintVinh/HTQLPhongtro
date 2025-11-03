using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class ThongBao
{
    public int IdTb { get; set; }

    public int? IdChu { get; set; }

    public string LoaiTb { get; set; } = null!;

    public string TieuDe { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public string MucDo { get; set; } = null!;

    public DateTime NgayGui { get; set; }

    public DateTime? NgayHetHan { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ChuTro? IdChuNavigation { get; set; }

    public virtual ICollection<NguoiNhanThongBao> NguoiNhanThongBaos { get; set; } = new List<NguoiNhanThongBao>();
}
