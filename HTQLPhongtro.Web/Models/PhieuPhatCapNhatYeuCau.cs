using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class PhieuPhatCapNhatYeuCau
{
    [StringLength(500)]
    public string? LyDo { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? SoTien { get; set; }
    
    [Required]
    public string TrangThai { get; set; } = "Unpaid";
    
    public DateOnly? NgayThanhToan { get; set; }
    
    [StringLength(500)]
    public string? GhiChu { get; set; }
}

