namespace HTQLPhongtro.Web.Models;

public class TaiSanMoHinh
{
    public int MaTaiSan { get; set; }
    public string TenTaiSan { get; set; } = string.Empty;
    public string? MoTa { get; set; }
    public string? DonViTinh { get; set; }
    public decimal? GiaTri { get; set; }
}

