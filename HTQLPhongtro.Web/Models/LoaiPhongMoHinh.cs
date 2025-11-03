namespace HTQLPhongtro.Web.Models;

public class LoaiPhongMoHinh
{
    public int MaLoai { get; set; }
    public string TenLoai { get; set; } = string.Empty;
    public string? MoTa { get; set; }
    public decimal? GiaThueGocMin { get; set; }
    public decimal? GiaThueGocMax { get; set; }
    public bool IsActive { get; set; }
}


