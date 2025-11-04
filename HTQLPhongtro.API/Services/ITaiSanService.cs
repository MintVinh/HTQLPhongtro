using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface ITaiSanService
{
    Task<IEnumerable<TaiSanThongTinDTO>> LayTatCaAsync();
    Task<TaiSanThongTinDTO?> LayTheoIdAsync(int id);
    Task<TaiSanThongTinDTO> TaoMoiAsync(TaiSanTaoDTO dto);
    Task CapNhatAsync(int id, TaiSanCapNhatDTO dto);
    Task XoaAsync(int id);
}

