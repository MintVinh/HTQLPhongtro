using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class TaiSanCapNhatYeuCau
{
    [Required(ErrorMessage = "Tên tài sản là bắt buộc")]
    [StringLength(100)]
    public string TenTaiSan { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string? MoTa { get; set; }
    
    [StringLength(50)]
    public string? DonViTinh { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal? GiaTri { get; set; }
}

