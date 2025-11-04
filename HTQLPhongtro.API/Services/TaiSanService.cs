using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class TaiSanService : ITaiSanService
{
    private readonly IDonViCongViec _donViCongViec;

    public TaiSanService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<TaiSanThongTinDTO>> LayTatCaAsync()
    {
        var danhSach = await _donViCongViec.LayKhoLuuTru<TaiSan>().LayTatCaAsync();
        return danhSach.Select(t => new TaiSanThongTinDTO
        {
            MaTaiSan = t.IdTs,
            TenTaiSan = t.TenTs,
            MoTa = t.MoTa,
            DonViTinh = t.DonViTinh,
            GiaTri = t.GiaTri
        });
    }

    public async Task<TaiSanThongTinDTO?> LayTheoIdAsync(int id)
    {
        var taiSan = await _donViCongViec.LayKhoLuuTru<TaiSan>().LayTheoIdAsync(id);
        if (taiSan == null) return null;

        return new TaiSanThongTinDTO
        {
            MaTaiSan = taiSan.IdTs,
            TenTaiSan = taiSan.TenTs,
            MoTa = taiSan.MoTa,
            DonViTinh = taiSan.DonViTinh,
            GiaTri = taiSan.GiaTri
        };
    }

    public async Task<TaiSanThongTinDTO> TaoMoiAsync(TaiSanTaoDTO dto)
    {
        var taiSanMoi = new TaiSan
        {
            TenTs = dto.TenTaiSan,
            MoTa = dto.MoTa,
            DonViTinh = dto.DonViTinh,
            GiaTri = dto.GiaTri,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<TaiSan>().ThemMoiAsync(taiSanMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new TaiSanThongTinDTO
        {
            MaTaiSan = taiSanMoi.IdTs,
            TenTaiSan = taiSanMoi.TenTs,
            MoTa = taiSanMoi.MoTa,
            DonViTinh = taiSanMoi.DonViTinh,
            GiaTri = taiSanMoi.GiaTri
        };
    }

    public async Task CapNhatAsync(int id, TaiSanCapNhatDTO dto)
    {
        var taiSan = await _donViCongViec.LayKhoLuuTru<TaiSan>().LayTheoIdAsync(id);
        if (taiSan == null)
            throw new KeyNotFoundException($"Không tìm thấy tài sản với ID: {id}");

        taiSan.TenTs = dto.TenTaiSan;
        taiSan.MoTa = dto.MoTa;
        taiSan.DonViTinh = dto.DonViTinh;
        taiSan.GiaTri = dto.GiaTri;

        _donViCongViec.LayKhoLuuTru<TaiSan>().CapNhat(taiSan);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var taiSan = await _donViCongViec.LayKhoLuuTru<TaiSan>().LayTheoIdAsync(id);
        if (taiSan == null)
            throw new KeyNotFoundException($"Không tìm thấy tài sản với ID: {id}");

        _donViCongViec.LayKhoLuuTru<TaiSan>().Xoa(taiSan);
        await _donViCongViec.LuuThayDoiAsync();
    }
}

