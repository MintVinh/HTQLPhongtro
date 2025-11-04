namespace HTQLPhongtro.Web.Models;

public class KhachHangMoHinh
{
    public int MaKhach { get; set; }
    public int? MaTaiKhoan { get; set; }
    public string HoTen { get; set; } = string.Empty;
    public string Cccd { get; set; } = string.Empty;
    public string Sdt { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? DiaChi { get; set; }
    public DateOnly? NgaySinh { get; set; }
    public string? NgheNghiep { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public string? GhiChu { get; set; }
}

