using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class LoaiPhongService : ILoaiPhongService
{
    private readonly IDonViCongViec _donViCongViec;

    public LoaiPhongService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<LoaiPhongThongTinDTO>> LayTatCaAsync()
    {
        var list = await _donViCongViec.LayKhoLuuTru<LoaiPhong>().LayTatCaAsync();
        return list.Select(l => new LoaiPhongThongTinDTO
        {
            MaLoai = l.IdLoai,
            TenLoai = l.TenLoai,
            MoTa = l.MoTa,
            GiaThueGocMin = l.GiaThueGocMin,
            GiaThueGocMax = l.GiaThueGocMax,
            IsActive = l.IsActive
        });
    }

    public async Task<IEnumerable<LoaiPhongThongTinDTO>> TimKiemAsync(string? tuKhoa, bool? isActive)
    {
        IEnumerable<LoaiPhong> list;
        if (!string.IsNullOrWhiteSpace(tuKhoa) || isActive.HasValue)
        {
            list = await _donViCongViec
                .LayKhoLuuTru<LoaiPhong>()
                .TimKiemAsync(x =>
                    (string.IsNullOrEmpty(tuKhoa) || x.TenLoai.Contains(tuKhoa)) &&
                    (!isActive.HasValue || x.IsActive == isActive.Value)
                );
        }
        else
        {
            list = await _donViCongViec.LayKhoLuuTru<LoaiPhong>().LayTatCaAsync();
        }

        return list.Select(l => new LoaiPhongThongTinDTO
        {
            MaLoai = l.IdLoai,
            TenLoai = l.TenLoai,
            MoTa = l.MoTa,
            GiaThueGocMin = l.GiaThueGocMin,
            GiaThueGocMax = l.GiaThueGocMax,
            IsActive = l.IsActive
        });
    }

    public async Task<LoaiPhongThongTinDTO?> LayTheoIdAsync(int id)
    {
        var lp = await _donViCongViec.LayKhoLuuTru<LoaiPhong>().LayTheoIdAsync(id);
        return lp == null ? null : new LoaiPhongThongTinDTO
        {
            MaLoai = lp.IdLoai,
            TenLoai = lp.TenLoai,
            MoTa = lp.MoTa,
            GiaThueGocMin = lp.GiaThueGocMin,
            GiaThueGocMax = lp.GiaThueGocMax,
            IsActive = lp.IsActive
        };
    }

    public async Task<LoaiPhongThongTinDTO> TaoMoiAsync(LoaiPhongTaoDTO taoDto)
    {
        var entity = new LoaiPhong
        {
            TenLoai = taoDto.TenLoai,
            MoTa = taoDto.MoTa,
            GiaThueGocMin = taoDto.GiaThueGocMin,
            GiaThueGocMax = taoDto.GiaThueGocMax,
            IsActive = true
        };
        await _donViCongViec.LayKhoLuuTru<LoaiPhong>().ThemMoiAsync(entity);
        await _donViCongViec.LuuThayDoiAsync();
        return new LoaiPhongThongTinDTO
        {
            MaLoai = entity.IdLoai,
            TenLoai = entity.TenLoai,
            MoTa = entity.MoTa,
            GiaThueGocMin = entity.GiaThueGocMin,
            GiaThueGocMax = entity.GiaThueGocMax,
            IsActive = entity.IsActive
        };
    }

    public async Task CapNhatAsync(int id, LoaiPhongCapNhatDTO capNhatDto)
    {
        var entity = await _donViCongViec.LayKhoLuuTru<LoaiPhong>().LayTheoIdAsync(id);
        if (entity == null) throw new KeyNotFoundException();
        entity.TenLoai = capNhatDto.TenLoai;
        entity.MoTa = capNhatDto.MoTa;
        entity.GiaThueGocMin = capNhatDto.GiaThueGocMin;
        entity.GiaThueGocMax = capNhatDto.GiaThueGocMax;
        entity.IsActive = capNhatDto.IsActive;
        _donViCongViec.LayKhoLuuTru<LoaiPhong>().CapNhat(entity);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var entity = await _donViCongViec.LayKhoLuuTru<LoaiPhong>().LayTheoIdAsync(id);
        if (entity == null) throw new KeyNotFoundException();
        _donViCongViec.LayKhoLuuTru<LoaiPhong>().Xoa(entity);
        await _donViCongViec.LuuThayDoiAsync();
    }
}


