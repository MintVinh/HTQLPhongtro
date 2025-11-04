namespace HTQLPhongtro.API.DTOs;

public class PhieuPhatThongTinDTO
{
    public int MaPhieuPhat { get; set; }
    public int MaHopDong { get; set; }
    public int? MaQuyDinhPhat { get; set; }
    public string LyDo { get; set; } = null!;
    public decimal SoTien { get; set; }
    public DateOnly NgayPhat { get; set; }
    public string TrangThai { get; set; } = null!;
    public DateOnly? NgayThanhToan { get; set; }
    public string? GhiChu { get; set; }
}

public class PhieuPhatTaoDTO
{
    public int MaHopDong { get; set; }
    public int? MaQuyDinhPhat { get; set; }
    public string LyDo { get; set; } = null!;
    public decimal SoTien { get; set; }
    public DateOnly NgayPhat { get; set; }
    public string? GhiChu { get; set; }
}

public class PhieuPhatCapNhatDTO
{
    public string? LyDo { get; set; }
    public decimal? SoTien { get; set; }
    public string TrangThai { get; set; } = null!;
    public DateOnly? NgayThanhToan { get; set; }
    public string? GhiChu { get; set; }
}

