namespace HTQLPhongtro.Web.Models;

public class PhieuPhatMoHinh
{
    public int MaPhieuPhat { get; set; }
    public int MaHopDong { get; set; }
    public int? MaQuyDinhPhat { get; set; }
    public string LyDo { get; set; } = string.Empty;
    public decimal SoTien { get; set; }
    public DateOnly NgayPhat { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public DateOnly? NgayThanhToan { get; set; }
    public string? GhiChu { get; set; }
}

