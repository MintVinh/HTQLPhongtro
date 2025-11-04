using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface IYeuCauSuaChuaService
{
    Task<IEnumerable<YeuCauSuaChuaThongTinDTO>> LayTatCaAsync();
    Task<IEnumerable<YeuCauSuaChuaThongTinDTO>> TimKiemAsync(string? tuKhoa, string? trangThai);
    Task<YeuCauSuaChuaThongTinDTO?> LayTheoIdAsync(int id);
    Task<YeuCauSuaChuaThongTinDTO> TaoMoiAsync(YeuCauSuaChuaTaoDTO dto);
    Task CapNhatAsync(int id, YeuCauSuaChuaCapNhatDTO dto);
    Task XoaAsync(int id);
}

