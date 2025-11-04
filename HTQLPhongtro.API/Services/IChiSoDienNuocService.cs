using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface IChiSoDienNuocService
{
    Task<IEnumerable<ChiSoDienNuocThongTinDTO>> LayTatCaAsync();
    Task<IEnumerable<ChiSoDienNuocThongTinDTO>> TimKiemAsync(int? maPhong, int? thang, int? nam);
    Task<ChiSoDienNuocThongTinDTO?> LayTheoIdAsync(int id);
    Task<ChiSoDienNuocThongTinDTO> TaoMoiAsync(ChiSoDienNuocTaoDTO dto);
    Task CapNhatAsync(int id, ChiSoDienNuocCapNhatDTO dto);
    Task XoaAsync(int id);
}

