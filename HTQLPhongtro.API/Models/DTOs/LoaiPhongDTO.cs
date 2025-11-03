namespace HTQLPhongtro.API.DTOs;

public class LoaiPhongThongTinDTO
{
    public int MaLoai { get; set; }
    public string TenLoai { get; set; } = null!;
    public string? MoTa { get; set; }
    public decimal? GiaThueGocMin { get; set; }
    public decimal? GiaThueGocMax { get; set; }
    public bool IsActive { get; set; }
}

public class LoaiPhongTaoDTO
{
    public string TenLoai { get; set; } = null!;
    public string? MoTa { get; set; }
    public decimal? GiaThueGocMin { get; set; }
    public decimal? GiaThueGocMax { get; set; }
}

public class LoaiPhongCapNhatDTO
{
    public string TenLoai { get; set; } = null!;
    public string? MoTa { get; set; }
    public decimal? GiaThueGocMin { get; set; }
    public decimal? GiaThueGocMax { get; set; }
    public bool IsActive { get; set; }
}


