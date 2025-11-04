namespace HTQLPhongtro.Web.Models;

public class ChiSoDienNuocMoHinh
{
    public int MaChiSo { get; set; }
    public int MaPhong { get; set; }
    public int Thang { get; set; }
    public int Nam { get; set; }
    public double ChiSoDienCu { get; set; }
    public double ChiSoDienMoi { get; set; }
    public double TieuThuDien { get; set; }
    public double ChiSoNuocCu { get; set; }
    public double ChiSoNuocMoi { get; set; }
    public double TieuThuNuoc { get; set; }
    public DateOnly NgayGhi { get; set; }
    public int? NguoiGhi { get; set; }
    public string? GhiChu { get; set; }
}

