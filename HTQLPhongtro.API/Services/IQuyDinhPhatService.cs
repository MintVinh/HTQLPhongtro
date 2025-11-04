using HTQLPhongtro.API.DTOs;

namespace HTQLPhongtro.API.Services;

public interface IQuyDinhPhatService
{
    Task<IEnumerable<QuyDinhPhatThongTinDTO>> LayTatCaAsync();
    Task<QuyDinhPhatThongTinDTO?> LayTheoIdAsync(int id);
    Task<QuyDinhPhatThongTinDTO> TaoMoiAsync(QuyDinhPhatTaoDTO dto);
    Task CapNhatAsync(int id, QuyDinhPhatCapNhatDTO dto);
    Task XoaAsync(int id);
}

