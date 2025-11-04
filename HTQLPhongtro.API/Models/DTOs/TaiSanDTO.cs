namespace HTQLPhongtro.API.DTOs;

public class TaiSanThongTinDTO
{
    public int MaTaiSan { get; set; }
    public string TenTaiSan { get; set; } = null!;
    public string? MoTa { get; set; }
    public string? DonViTinh { get; set; }
    public decimal? GiaTri { get; set; }
}

public class TaiSanTaoDTO
{
    public string TenTaiSan { get; set; } = null!;
    public string? MoTa { get; set; }
    public string? DonViTinh { get; set; }
    public decimal? GiaTri { get; set; }
}

public class TaiSanCapNhatDTO
{
    public string TenTaiSan { get; set; } = null!;
    public string? MoTa { get; set; }
    public string? DonViTinh { get; set; }
    public decimal? GiaTri { get; set; }
}

