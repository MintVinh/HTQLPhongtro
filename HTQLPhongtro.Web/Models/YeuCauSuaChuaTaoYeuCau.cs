using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class YeuCauSuaChuaTaoYeuCau
{
    [Required]
    public int MaPhong { get; set; }
    
    [Required]
    public int MaKhach { get; set; }
    
    [Required(ErrorMessage = "Tiêu đề là bắt buộc")]
    [StringLength(200)]
    public string TieuDe { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Mô tả là bắt buộc")]
    public string MoTa { get; set; } = string.Empty;
    
    [Required]
    public string MucDo { get; set; } = "Normal";
}

