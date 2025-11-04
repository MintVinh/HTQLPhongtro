namespace HTQLPhongtro.Web.Models;

public class YeuCauSuaChuaMoHinh
{
    public int MaYeuCau { get; set; }
    public int MaPhong { get; set; }
    public int MaKhach { get; set; }
    public string TieuDe { get; set; } = string.Empty;
    public string MoTa { get; set; } = string.Empty;
    public string MucDo { get; set; } = string.Empty;
    public string TrangThai { get; set; } = string.Empty;
    public DateTime NgayYeuCau { get; set; }
    public DateTime? NgayXuLy { get; set; }
    public DateTime? NgayHoanThanh { get; set; }
    public int? NguoiXuLy { get; set; }
    public decimal? ChiPhi { get; set; }
    public string? GhiChu { get; set; }
}

