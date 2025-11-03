using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface ILoaiPhongService
{
    Task<IEnumerable<LoaiPhongThongTinDTO>> LayTatCaAsync();
    Task<IEnumerable<LoaiPhongThongTinDTO>> TimKiemAsync(string? tuKhoa, bool? isActive);
    Task<LoaiPhongThongTinDTO?> LayTheoIdAsync(int id);
    Task<LoaiPhongThongTinDTO> TaoMoiAsync(LoaiPhongTaoDTO taoDto);
    Task CapNhatAsync(int id, LoaiPhongCapNhatDTO capNhatDto);
    Task XoaAsync(int id);
}


