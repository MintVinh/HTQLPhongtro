namespace HTQLPhongtro.API.DTOs;

public class KhachHangThongTinDTO
{
    public int MaKhach { get; set; }
    public int? MaTaiKhoan { get; set; }
    public string HoTen { get; set; } = null!;
    public string Cccd { get; set; } = null!;
    public string Sdt { get; set; } = null!;
    public string? Email { get; set; }
    public string? DiaChi { get; set; }
    public DateOnly? NgaySinh { get; set; }
    public string? NgheNghiep { get; set; }
    public string TrangThai { get; set; } = null!;
    public string? GhiChu { get; set; }
}

public class KhachHangTaoDTO
{
    public int? MaTaiKhoan { get; set; }
    public string HoTen { get; set; } = null!;
    public string Cccd { get; set; } = null!;
    public string Sdt { get; set; } = null!;
    public string? Email { get; set; }
    public string? DiaChi { get; set; }
    public DateOnly? NgaySinh { get; set; }
    public string? NgheNghiep { get; set; }
    public string? GhiChu { get; set; }
}

public class KhachHangCapNhatDTO
{
    public int? MaTaiKhoan { get; set; }
    public string HoTen { get; set; } = null!;
    public string Cccd { get; set; } = null!;
    public string Sdt { get; set; } = null!;
    public string? Email { get; set; }
    public string? DiaChi { get; set; }
    public DateOnly? NgaySinh { get; set; }
    public string? NgheNghiep { get; set; }
    public string TrangThai { get; set; } = null!;
    public string? GhiChu { get; set; }
}

