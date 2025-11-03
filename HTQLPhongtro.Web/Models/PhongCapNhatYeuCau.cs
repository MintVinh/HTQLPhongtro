using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class PhongCapNhatYeuCau
{
    [Required]
    [StringLength(50)]
    public string TenPhong { get; set; } = string.Empty;
    [Range(0, double.MaxValue)]
    public decimal GiaThue { get; set; }
    [Range(1, 20)]
    public int SoNguoiToiDa { get; set; } = 2;
    public string? MoTa { get; set; }
}


