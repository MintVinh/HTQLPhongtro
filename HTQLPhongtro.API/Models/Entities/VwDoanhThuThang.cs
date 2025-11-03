using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class VwDoanhThuThang
{
    public int Nam { get; set; }

    public int Thang { get; set; }

    public int? SoHoaDon { get; set; }

    public decimal? TongDoanhThu { get; set; }

    public decimal? DaThanhToan { get; set; }

    public decimal? ChuaThanhToan { get; set; }

    public decimal? TongTienPhong { get; set; }

    public decimal? TongTienDien { get; set; }

    public decimal? TongTienNuoc { get; set; }
}
