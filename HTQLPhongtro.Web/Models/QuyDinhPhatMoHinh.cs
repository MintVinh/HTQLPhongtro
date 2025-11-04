namespace HTQLPhongtro.Web.Models;

public class QuyDinhPhatMoHinh
{
    public int MaQuyDinh { get; set; }
    public string LoaiViPham { get; set; } = string.Empty;
    public string? MoTa { get; set; }
    public decimal MucPhat { get; set; }
    public string DonVi { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

