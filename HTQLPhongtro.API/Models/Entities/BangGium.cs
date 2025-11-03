using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class BangGium
{
    public int IdBg { get; set; }

    public string LoaiDichVu { get; set; } = null!;

    public decimal DonGia { get; set; }

    public string DonVi { get; set; } = null!;

    public DateOnly NgayApDung { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
}
