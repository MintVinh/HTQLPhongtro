namespace HTQLPhongtro.Web.Models;

public class HopDongMoHinh
{
    public int MaHopDong { get; set; }
    public int MaPhong { get; set; }
    public int MaKhach { get; set; }
    public int? MaDatCoc { get; set; }
    public string MaHopDongString { get; set; } = string.Empty;
    public DateOnly NgayBatDau { get; set; }
    public DateOnly NgayKetThuc { get; set; }
    public decimal TienCoc { get; set; }
    public decimal GiaThue { get; set; }
    public int ChuKyThanhToan { get; set; }
    public int NgayThanhToan { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public string? GhiChu { get; set; }
    public string? FileDinhKem { get; set; }
}

