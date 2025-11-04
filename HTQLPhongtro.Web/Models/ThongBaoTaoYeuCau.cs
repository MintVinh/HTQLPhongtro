using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class ThongBaoTaoYeuCau
{
    public int? MaChuTro { get; set; }
    
    [Required(ErrorMessage = "Loại thông báo là bắt buộc")]
    [StringLength(50)]
    public string LoaiThongBao { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Tiêu đề là bắt buộc")]
    [StringLength(200)]
    public string TieuDe { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Nội dung là bắt buộc")]
    public string NoiDung { get; set; } = string.Empty;
    
    [Required]
    public string MucDo { get; set; } = "Normal";
    
    public DateTime? NgayHetHan { get; set; }
}

