namespace HTQLPhongtro.API.DTOs;

public class HopDongThongTinDTO
{
    public int MaHopDong { get; set; }
    public int MaPhong { get; set; }
    public int MaKhach { get; set; }
    public int? MaDatCoc { get; set; }
    public string MaHopDongString { get; set; } = null!;
    public DateOnly NgayBatDau { get; set; }
    public DateOnly NgayKetThuc { get; set; }
    public decimal TienCoc { get; set; }
    public decimal GiaThue { get; set; }
    public int ChuKyThanhToan { get; set; }
    public int NgayThanhToan { get; set; }
    public string TrangThai { get; set; } = null!;
    public string? GhiChu { get; set; }
    public string? FileDinhKem { get; set; }
}

public class HopDongTaoDTO
{
    public int MaPhong { get; set; }
    public int MaKhach { get; set; }
    public int? MaDatCoc { get; set; }
    public string MaHopDongString { get; set; } = null!;
    public DateOnly NgayBatDau { get; set; }
    public DateOnly NgayKetThuc { get; set; }
    public decimal TienCoc { get; set; }
    public decimal GiaThue { get; set; }
    public int ChuKyThanhToan { get; set; }
    public int NgayThanhToan { get; set; }
    public string? GhiChu { get; set; }
    public string? FileDinhKem { get; set; }
}

public class HopDongCapNhatDTO
{
    public DateOnly NgayKetThuc { get; set; }
    public decimal GiaThue { get; set; }
    public int ChuKyThanhToan { get; set; }
    public int NgayThanhToan { get; set; }
    public string TrangThai { get; set; } = null!;
    public string? GhiChu { get; set; }
    public string? FileDinhKem { get; set; }
}

