using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface IThongBaoService
{
    Task<IEnumerable<ThongBaoThongTinDTO>> LayTatCaAsync();
    Task<ThongBaoThongTinDTO?> LayTheoIdAsync(int id);
    Task<ThongBaoThongTinDTO> TaoMoiAsync(ThongBaoTaoDTO dto);
    Task CapNhatAsync(int id, ThongBaoCapNhatDTO dto);
    Task XoaAsync(int id);
}

