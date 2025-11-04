namespace HTQLPhongtro.API.DTOs;

public class ThongBaoThongTinDTO
{
    public int MaThongBao { get; set; }
    public int? MaChuTro { get; set; }
    public string LoaiThongBao { get; set; } = null!;
    public string TieuDe { get; set; } = null!;
    public string NoiDung { get; set; } = null!;
    public string MucDo { get; set; } = null!;
    public DateTime NgayGui { get; set; }
    public DateTime? NgayHetHan { get; set; }
    public bool IsActive { get; set; }
}

public class ThongBaoTaoDTO
{
    public int? MaChuTro { get; set; }
    public string LoaiThongBao { get; set; } = null!;
    public string TieuDe { get; set; } = null!;
    public string NoiDung { get; set; } = null!;
    public string MucDo { get; set; } = "Normal";
    public DateTime? NgayHetHan { get; set; }
}

public class ThongBaoCapNhatDTO
{
    public string LoaiThongBao { get; set; } = null!;
    public string TieuDe { get; set; } = null!;
    public string NoiDung { get; set; } = null!;
    public string MucDo { get; set; } = null!;
    public DateTime? NgayHetHan { get; set; }
    public bool IsActive { get; set; }
}

