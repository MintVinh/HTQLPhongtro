using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface IHoaDonThueService
{
    Task<IEnumerable<HoaDonThueThongTinDTO>> LayTatCaAsync();
    Task<IEnumerable<HoaDonThueThongTinDTO>> TimKiemAsync(int? maHopDong, int? thang, int? nam, string? trangThai);
    Task<HoaDonThueThongTinDTO?> LayTheoIdAsync(int id);
    Task<HoaDonThueThongTinDTO> TaoMoiAsync(HoaDonThueTaoDTO dto);
    Task CapNhatAsync(int id, HoaDonThueCapNhatDTO dto);
    Task XoaAsync(int id);
}

