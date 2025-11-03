using System.ComponentModel.DataAnnotations;

namespace HTQLPhongtro.Web.Models;

public class PhongTaoYeuCau
{
    [Required]
    public int MaChuTro { get; set; }
    [Required]
    public int MaLoaiPhong { get; set; }
    [Required]
    [StringLength(50)]
    public string TenPhong { get; set; } = string.Empty;
    [Range(1, 100)]
    public int Tang { get; set; } = 1;
    [Range(0, 1000)]
    public double DienTich { get; set; }
    [Range(0, double.MaxValue)]
    public decimal GiaThue { get; set; }
    [Range(1, 20)]
    public int SoNguoiToiDa { get; set; } = 2;
    public string? MoTa { get; set; }
}


