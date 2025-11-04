namespace HTQLPhongtro.Web.Models;

public class HoaDonThueMoHinh
{
    public int MaHoaDon { get; set; }
    public int MaHopDong { get; set; }
    public int? MaChiSo { get; set; }
    public string MaHoaDonString { get; set; } = string.Empty;
    public int Thang { get; set; }
    public int Nam { get; set; }
    public decimal TienPhong { get; set; }
    public decimal TienDien { get; set; }
    public decimal TienNuoc { get; set; }
    public decimal TienMang { get; set; }
    public decimal TienRac { get; set; }
    public decimal TienGuiXe { get; set; }
    public decimal TienPhat { get; set; }
    public decimal GiamGia { get; set; }
    public decimal TongTien { get; set; }
    public DateOnly HanThanhToan { get; set; }
    public DateOnly? NgayThanhToan { get; set; }
    public string TrangThai { get; set; } = string.Empty;
    public string? GhiChu { get; set; }
}

