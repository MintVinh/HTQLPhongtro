using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class YeuCauSuaChua
{
    public int IdYc { get; set; }

    public int IdPhong { get; set; }

    public int IdKhach { get; set; }

    public string TieuDe { get; set; } = null!;

    public string MoTa { get; set; } = null!;

    public string MucDo { get; set; } = null!;

    public string TrangThai { get; set; } = null!;

    public DateTime NgayYeuCau { get; set; }

    public DateTime? NgayXuLy { get; set; }

    public DateTime? NgayHoanThanh { get; set; }

    public int? NguoiXuLy { get; set; }

    public decimal? ChiPhi { get; set; }

    public string? GhiChu { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<HinhAnhYeuCau> HinhAnhYeuCaus { get; set; } = new List<HinhAnhYeuCau>();

    public virtual KhachHang IdKhachNavigation { get; set; } = null!;

    public virtual Phong IdPhongNavigation { get; set; } = null!;
}
