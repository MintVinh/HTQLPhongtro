using System;
using System.Collections.Generic;

namespace HTQLPhongtro.API.Models.Entities;

public partial class QuyDinhPhat
{
    public int IdQdp { get; set; }

    public string LoaiViPham { get; set; } = null!;

    public string? MoTa { get; set; }

    public decimal MucPhat { get; set; }

    public string DonVi { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<PhieuPhat> PhieuPhats { get; set; } = new List<PhieuPhat>();
}
