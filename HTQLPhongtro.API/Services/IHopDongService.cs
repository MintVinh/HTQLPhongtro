using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface IHopDongService
{
    Task<IEnumerable<HopDongThongTinDTO>> LayTatCaAsync();
    Task<IEnumerable<HopDongThongTinDTO>> TimKiemAsync(string? tuKhoa, string? trangThai);
    Task<HopDongThongTinDTO?> LayTheoIdAsync(int id);
    Task<HopDongThongTinDTO> TaoMoiAsync(HopDongTaoDTO dto);
    Task CapNhatAsync(int id, HopDongCapNhatDTO dto);
    Task XoaAsync(int id);
}

