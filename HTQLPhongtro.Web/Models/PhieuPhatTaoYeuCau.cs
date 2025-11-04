using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class PhieuPhatTaoYeuCau
{
    [Required]
    public int MaHopDong { get; set; }
    
    public int? MaQuyDinhPhat { get; set; }
    
    [Required(ErrorMessage = "Lý do là bắt buộc")]
    [StringLength(500)]
    public string LyDo { get; set; } = string.Empty;
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal SoTien { get; set; }
    
    [Required]
    public DateOnly NgayPhat { get; set; }
    
    [StringLength(500)]
    public string? GhiChu { get; set; }
}

