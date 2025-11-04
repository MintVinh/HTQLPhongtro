using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface IPhieuPhatService
{
    Task<IEnumerable<PhieuPhatThongTinDTO>> LayTatCaAsync();
    Task<IEnumerable<PhieuPhatThongTinDTO>> TimKiemAsync(int? maHopDong, string? trangThai);
    Task<PhieuPhatThongTinDTO?> LayTheoIdAsync(int id);
    Task<PhieuPhatThongTinDTO> TaoMoiAsync(PhieuPhatTaoDTO dto);
    Task CapNhatAsync(int id, PhieuPhatCapNhatDTO dto);
    Task XoaAsync(int id);
}

