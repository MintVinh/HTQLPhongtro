namespace HTQLPhongtro.API.DTOs;

public class YeuCauSuaChuaThongTinDTO
{
    public int MaYeuCau { get; set; }
    public int MaPhong { get; set; }
    public int MaKhach { get; set; }
    public string TieuDe { get; set; } = null!;
    public string MoTa { get; set; } = null!;
    public string MucDo { get; set; } = null!;
    public string TrangThai { get; set; } = null!;
    public DateTime NgayYeuCau { get; set; }
    public DateTime? NgayXuLy { get; set; }
    public DateTime? NgayHoanThanh { get; set; }
    public int? NguoiXuLy { get; set; }
    public decimal? ChiPhi { get; set; }
    public string? GhiChu { get; set; }
}

public class YeuCauSuaChuaTaoDTO
{
    public int MaPhong { get; set; }
    public int MaKhach { get; set; }
    public string TieuDe { get; set; } = null!;
    public string MoTa { get; set; } = null!;
    public string MucDo { get; set; } = "Normal";
}

public class YeuCauSuaChuaCapNhatDTO
{
    public string? TieuDe { get; set; }
    public string? MoTa { get; set; }
    public string? MucDo { get; set; }
    public string TrangThai { get; set; } = null!;
    public DateTime? NgayXuLy { get; set; }
    public DateTime? NgayHoanThanh { get; set; }
    public int? NguoiXuLy { get; set; }
    public decimal? ChiPhi { get; set; }
    public string? GhiChu { get; set; }
}

