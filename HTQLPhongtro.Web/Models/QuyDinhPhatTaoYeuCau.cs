using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class QuyDinhPhatTaoYeuCau
{
    [Required(ErrorMessage = "Loại vi phạm là bắt buộc")]
    [StringLength(100)]
    public string LoaiViPham { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string? MoTa { get; set; }
    
    [Required]
    [Range(0, double.MaxValue)]
    public decimal MucPhat { get; set; }
    
    [Required]
    [StringLength(20)]
    public string DonVi { get; set; } = "VND";
}

