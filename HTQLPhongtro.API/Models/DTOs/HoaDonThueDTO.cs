namespace HTQLPhongtro.API.DTOs;

public class HoaDonThueThongTinDTO
{
    public int MaHoaDon { get; set; }
    public int MaHopDong { get; set; }
    public int? MaChiSo { get; set; }
    public string MaHoaDonString { get; set; } = null!;
    public int Thang { get; set; }
    public int Nam { get; set; }
    public decimal TienPhong { get; set; }
    public decimal TienDien { get; set; }
    public decimal TienNuoc { get; set; }
    public decimal TienMang { get; set; }
    public decimal TienRac { get; set; }
    public decimal TienGuiXe { get; set; }
    public decimal TienPhat { get; set; }
    public decimal GiamGia { get; set; }
    public decimal TongTien { get; set; }
    public DateOnly HanThanhToan { get; set; }
    public DateOnly? NgayThanhToan { get; set; }
    public string TrangThai { get; set; } = null!;
    public string? GhiChu { get; set; }
}

public class HoaDonThueTaoDTO
{
    public int MaHopDong { get; set; }
    public int? MaChiSo { get; set; }
    public string MaHoaDonString { get; set; } = null!;
    public int Thang { get; set; }
    public int Nam { get; set; }
    public decimal TienPhong { get; set; }
    public decimal TienDien { get; set; }
    public decimal TienNuoc { get; set; }
    public decimal TienMang { get; set; }
    public decimal TienRac { get; set; }
    public decimal TienGuiXe { get; set; }
    public decimal TienPhat { get; set; }
    public decimal GiamGia { get; set; }
    public DateOnly HanThanhToan { get; set; }
    public string? GhiChu { get; set; }
}

public class HoaDonThueCapNhatDTO
{
    public decimal? TienPhong { get; set; }
    public decimal? TienDien { get; set; }
    public decimal? TienNuoc { get; set; }
    public decimal? TienMang { get; set; }
    public decimal? TienRac { get; set; }
    public decimal? TienGuiXe { get; set; }
    public decimal? TienPhat { get; set; }
    public decimal? GiamGia { get; set; }
    public DateOnly? NgayThanhToan { get; set; }
    public string TrangThai { get; set; } = null!;
    public string? GhiChu { get; set; }
}

