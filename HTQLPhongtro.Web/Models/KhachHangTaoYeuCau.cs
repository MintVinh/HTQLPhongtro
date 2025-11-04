using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class KhachHangTaoYeuCau
{
    public int? MaTaiKhoan { get; set; }
    
    [Required(ErrorMessage = "Họ tên là bắt buộc")]
    [StringLength(100)]
    public string HoTen { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "CCCD là bắt buộc")]
    [StringLength(12)]
    public string Cccd { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
    [StringLength(15)]
    public string Sdt { get; set; } = string.Empty;
    
    [EmailAddress]
    [StringLength(100)]
    public string? Email { get; set; }
    
    [StringLength(500)]
    public string? DiaChi { get; set; }
    
    public DateOnly? NgaySinh { get; set; }
    
    [StringLength(100)]
    public string? NgheNghiep { get; set; }
    
    [StringLength(500)]
    public string? GhiChu { get; set; }
}

