using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class YeuCauSuaChuaCapNhatYeuCau
{
    [StringLength(200)]
    public string? TieuDe { get; set; }
    
    public string? MoTa { get; set; }
    
    public string? MucDo { get; set; }
    
    [Required]
    public string TrangThai { get; set; } = "Pending";
    
    public DateTime? NgayXuLy { get; set; }
    
    public DateTime? NgayHoanThanh { get; set; }
    
    public int? NguoiXuLy { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? ChiPhi { get; set; }
    
    [StringLength(1000)]
    public string? GhiChu { get; set; }
}

