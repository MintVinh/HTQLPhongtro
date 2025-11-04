using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface IKhachHangService
{
    Task<IEnumerable<KhachHangThongTinDTO>> LayTatCaAsync();
    Task<IEnumerable<KhachHangThongTinDTO>> TimKiemAsync(string? tuKhoa, string? trangThai);
    Task<KhachHangThongTinDTO?> LayTheoIdAsync(int id);
    Task<KhachHangThongTinDTO> TaoMoiAsync(KhachHangTaoDTO dto);
    Task CapNhatAsync(int id, KhachHangCapNhatDTO dto);
    Task XoaAsync(int id);
}

