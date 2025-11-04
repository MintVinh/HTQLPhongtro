using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class ChiSoDienNuocTaoYeuCau
{
    [Required]
    public int MaPhong { get; set; }
    
    [Required]
    [Range(1, 12)]
    public int Thang { get; set; }
    
    [Required]
    [Range(2000, 2100)]
    public int Nam { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public double ChiSoDienCu { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public double ChiSoDienMoi { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public double ChiSoNuocCu { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public double ChiSoNuocMoi { get; set; }
    
    [Required]
    public DateOnly NgayGhi { get; set; }
    
    public int? NguoiGhi { get; set; }
    
    [StringLength(500)]
    public string? GhiChu { get; set; }
}

