using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class HopDong
{
    public int IdHd { get; set; }

    public int IdPhong { get; set; }

    public int IdKhach { get; set; }

    public int? IdCoc { get; set; }

    public string MaHopDong { get; set; } = null!;

    public DateOnly NgayBatDau { get; set; }

    public DateOnly NgayKetThuc { get; set; }

    public decimal TienCoc { get; set; }

    public decimal GiaThue { get; set; }

    public int ChuKyThanhToan { get; set; }

    public int NgayThanhToan { get; set; }

    public string TrangThai { get; set; } = null!;

    public string? GhiChu { get; set; }

    public string? FileDinhKem { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public virtual BanGiaoPhong? BanGiaoPhong { get; set; }

    public virtual ICollection<HoaDonThue> HoaDonThues { get; set; } = new List<HoaDonThue>();

    public virtual DatCoc? IdCocNavigation { get; set; }

    public virtual KhachHang IdKhachNavigation { get; set; } = null!;

    public virtual Phong IdPhongNavigation { get; set; } = null!;

    public virtual ICollection<NguoiOcung> NguoiOcungs { get; set; } = new List<NguoiOcung>();

    public virtual ICollection<PhieuPhat> PhieuPhats { get; set; } = new List<PhieuPhat>();

    public virtual TraPhong? TraPhong { get; set; }
}
