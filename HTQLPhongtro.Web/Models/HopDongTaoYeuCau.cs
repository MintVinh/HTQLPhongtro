using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class HopDongTaoYeuCau
{
    [Required]
    public int MaPhong { get; set; }
    
    [Required]
    public int MaKhach { get; set; }
    
    public int? MaDatCoc { get; set; }
    
    [Required(ErrorMessage = "Mã hợp đồng là bắt buộc")]
    [StringLength(50)]
    public string MaHopDongString { get; set; } = string.Empty;
    
    [Required]
    public DateOnly NgayBatDau { get; set; }
    
    [Required]
    public DateOnly NgayKetThuc { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal TienCoc { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal GiaThue { get; set; }
    
    [Required]
    [Range(1, 12)]
    public int ChuKyThanhToan { get; set; } = 1;
    
    [Required]
    [Range(1, 31)]
    public int NgayThanhToan { get; set; } = 5;
    
    [StringLength(1000)]
    public string? GhiChu { get; set; }
    
    [StringLength(500)]
    public string? FileDinhKem { get; set; }
}

