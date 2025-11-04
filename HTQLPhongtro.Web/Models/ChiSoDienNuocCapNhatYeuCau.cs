using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class ChiSoDienNuocCapNhatYeuCau
{
    [Required]
    [Range(0, double.MaxValue)]
    public double ChiSoDienMoi { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public double ChiSoNuocMoi { get; set; }
    
    [Required]
    public DateOnly NgayGhi { get; set; }
    
    public int? NguoiGhi { get; set; }
    
    [StringLength(500)]
    public string? GhiChu { get; set; }
}

