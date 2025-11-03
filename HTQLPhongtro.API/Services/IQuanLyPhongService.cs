using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface IQuanLyPhongService
{
    Task<IEnumerable<ThongTinPhongDTO>> LayTatCaPhongAsync();
    Task<IEnumerable<ThongTinPhongDTO>> TimKiemPhongAsync(string? tuKhoa, string? trangThai);
    Task<ThongTinPhongDTO?> LayPhongTheoIdAsync(int id);
    Task<ThongTinPhongDTO> TaoPhongMoiAsync(TaoPhongMoiDTO taoPhongDto);
    Task CapNhatPhongAsync(int id, CapNhatPhongDTO capNhatPhongDto);
    Task XoaPhongAsync(int id);
}
