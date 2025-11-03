using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class VwPhongInfo
{
    public int IdPhong { get; set; }

    public string TenPhong { get; set; } = null!;

    public int Tang { get; set; }

    public double DienTich { get; set; }

    public decimal GiaThue { get; set; }

    public string TrangThai { get; set; } = null!;

    public string LoaiPhong { get; set; } = null!;

    public string ChuTro { get; set; } = null!;

    public string SdtChuTro { get; set; } = null!;

    public string? KhachThueHienTai { get; set; }

    public string? SdtKhachThue { get; set; }
}
