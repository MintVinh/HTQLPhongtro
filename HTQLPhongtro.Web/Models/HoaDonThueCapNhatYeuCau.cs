using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class HoaDonThueCapNhatYeuCau
{
    [Range(0, double.MaxValue)]
    public decimal? TienPhong { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? TienDien { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? TienNuoc { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? TienMang { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? TienRac { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? TienGuiXe { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? TienPhat { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? GiamGia { get; set; }
    
    [Required]
    public string TrangThai { get; set; } = "Unpaid";
    
    public DateOnly? NgayThanhToan { get; set; }
    
    [StringLength(1000)]
    public string? GhiChu { get; set; }
}

