using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class LoaiPhong
{
    public int IdLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public string? MoTa { get; set; }

    public double? DienTichTieuChuan { get; set; }

    public decimal? GiaThueGocMin { get; set; }

    public decimal? GiaThueGocMax { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Phong> Phongs { get; set; } = new List<Phong>();
}
