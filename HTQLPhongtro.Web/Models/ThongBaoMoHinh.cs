namespace HTQLPhongtro.Web.Models;

public class ThongBaoMoHinh
{
    public int MaThongBao { get; set; }
    public int? MaChuTro { get; set; }
    public string LoaiThongBao { get; set; } = string.Empty;
    public string TieuDe { get; set; } = string.Empty;
    public string NoiDung { get; set; } = string.Empty;
    public string MucDo { get; set; } = string.Empty;
    public DateTime NgayGui { get; set; }
    public DateTime? NgayHetHan { get; set; }
    public bool IsActive { get; set; }
}

