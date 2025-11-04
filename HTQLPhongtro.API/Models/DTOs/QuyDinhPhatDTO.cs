namespace HTQLPhongtro.API.DTOs;

public class QuyDinhPhatThongTinDTO
{
    public int MaQuyDinh { get; set; }
    public string LoaiViPham { get; set; } = null!;
    public string? MoTa { get; set; }
    public decimal MucPhat { get; set; }
    public string DonVi { get; set; } = null!;
    public bool IsActive { get; set; }
}

public class QuyDinhPhatTaoDTO
{
    public string LoaiViPham { get; set; } = null!;
    public string? MoTa { get; set; }
    public decimal MucPhat { get; set; }
    public string DonVi { get; set; } = "VND";
}

public class QuyDinhPhatCapNhatDTO
{
    public string LoaiViPham { get; set; } = null!;
    public string? MoTa { get; set; }
    public decimal MucPhat { get; set; }
    public string DonVi { get; set; } = null!;
    public bool IsActive { get; set; }
}

