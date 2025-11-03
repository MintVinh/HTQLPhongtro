namespace HTQLPhongtro.API.DTOs;

public class ThongTinPhongDTO
{
    public int MaPhong { get; set; }
    public string TenPhong { get; set; } = null!;
    public int Tang { get; set; }
    public double DienTich { get; set; }
    public decimal GiaThue { get; set; }
    public int SoNguoiToiDa { get; set; }
    public string TrangThai { get; set; } = null!;
    public string? MoTa { get; set; }
}

public class TaoPhongMoiDTO
{
    public int MaChuTro { get; set; }
    public int MaLoaiPhong { get; set; }
    public string TenPhong { get; set; } = null!;
    public int Tang { get; set; }
    public double DienTich { get; set; }
    public decimal GiaThue { get; set; }
    public int SoNguoiToiDa { get; set; }
    public string? MoTa { get; set; }
}

public class CapNhatPhongDTO
{
    public string TenPhong { get; set; } = null!;
    public decimal GiaThue { get; set; }
    public int SoNguoiToiDa { get; set; }
    public string? MoTa { get; set; }
}
