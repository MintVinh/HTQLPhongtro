using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class LoaiPhongTaoYeuCau
{
    [Required]
    [StringLength(100)]
    public string TenLoai { get; set; } = string.Empty;
    public string? MoTa { get; set; }
    public decimal? GiaThueGocMin { get; set; }
    public decimal? GiaThueGocMax { get; set; }
}


