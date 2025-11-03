using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class VwCongNo
{
    public int IdKhach { get; set; }

    public string HoTen { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string TenPhong { get; set; } = null!;

    public int? SoHoaDonChuaTt { get; set; }

    public decimal? TongCongNo { get; set; }

    public DateOnly? HanThanhToanGanNhat { get; set; }
}
