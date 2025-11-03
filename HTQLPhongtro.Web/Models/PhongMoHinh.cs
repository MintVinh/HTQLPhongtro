namespace HTQLPhongtro.Web.Models;

public class PhongMoHinh
{
    public int MaPhong { get; set; }
    public string TenPhong { get; set; } = string.Empty;
    public int Tang { get; set; }
    public double DienTich { get; set; }
    public decimal GiaThue { get; set; }
    public int SoNguoiToiDa { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public string? MoTa { get; set; }
}


