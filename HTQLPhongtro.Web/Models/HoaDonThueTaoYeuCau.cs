using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class HoaDonThueTaoYeuCau
{
    [Required]
    public int MaHopDong { get; set; }
    
    public int? MaChiSo { get; set; }
    
    [Required(ErrorMessage = "Mã hóa đơn là bắt buộc")]
    [StringLength(50)]
    public string MaHoaDonString { get; set; } = string.Empty;
    
    [Required]
    [Range(1, 12)]
    public int Thang { get; set; }
    
    [Required]
    [Range(2000, 2100)]
    public int Nam { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal TienPhong { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal TienDien { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal TienNuoc { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal TienMang { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal TienRac { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal TienGuiXe { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal TienPhat { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal GiamGia { get; set; }
    
    [Required]
    public DateOnly HanThanhToan { get; set; }
    
    [StringLength(1000)]
    public string? GhiChu { get; set; }
}

