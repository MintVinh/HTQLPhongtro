using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class HopDongCapNhatYeuCau
{
    [Required]
    public DateOnly NgayKetThuc { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal GiaThue { get; set; }
    
    [Required]
    [Range(1, 12)]
    public int ChuKyThanhToan { get; set; }
    
    [Required]
    [Range(1, 31)]
    public int NgayThanhToan { get; set; }
    
    [Required]
    public string TrangThai { get; set; } = "Active";
    
    [StringLength(1000)]
    public string? GhiChu { get; set; }
    
    [StringLength(500)]
    public string? FileDinhKem { get; set; }
}

