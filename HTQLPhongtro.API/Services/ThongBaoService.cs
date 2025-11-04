using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class ThongBaoService : IThongBaoService
{
    private readonly IDonViCongViec _donViCongViec;

    public ThongBaoService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<ThongBaoThongTinDTO>> LayTatCaAsync()
    {
        var danhSach = await _donViCongViec.LayKhoLuuTru<ThongBao>().LayTatCaAsync();
        return danhSach.Select(t => new ThongBaoThongTinDTO
        {
            MaThongBao = t.IdTb,
            MaChuTro = t.IdChu,
            LoaiThongBao = t.LoaiTb,
            TieuDe = t.TieuDe,
            NoiDung = t.NoiDung,
            MucDo = t.MucDo,
            NgayGui = t.NgayGui,
            NgayHetHan = t.NgayHetHan,
            IsActive = t.IsActive
        });
    }

    public async Task<ThongBaoThongTinDTO?> LayTheoIdAsync(int id)
    {
        var thongBao = await _donViCongViec.LayKhoLuuTru<ThongBao>().LayTheoIdAsync(id);
        if (thongBao == null) return null;

        return new ThongBaoThongTinDTO
        {
            MaThongBao = thongBao.IdTb,
            MaChuTro = thongBao.IdChu,
            LoaiThongBao = thongBao.LoaiTb,
            TieuDe = thongBao.TieuDe,
            NoiDung = thongBao.NoiDung,
            MucDo = thongBao.MucDo,
            NgayGui = thongBao.NgayGui,
            NgayHetHan = thongBao.NgayHetHan,
            IsActive = thongBao.IsActive
        };
    }

    public async Task<ThongBaoThongTinDTO> TaoMoiAsync(ThongBaoTaoDTO dto)
    {
        var thongBaoMoi = new ThongBao
        {
            IdChu = dto.MaChuTro,
            LoaiTb = dto.LoaiThongBao,
            TieuDe = dto.TieuDe,
            NoiDung = dto.NoiDung,
            MucDo = dto.MucDo,
            NgayGui = DateTime.UtcNow,
            NgayHetHan = dto.NgayHetHan,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<ThongBao>().ThemMoiAsync(thongBaoMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new ThongBaoThongTinDTO
        {
            MaThongBao = thongBaoMoi.IdTb,
            MaChuTro = thongBaoMoi.IdChu,
            LoaiThongBao = thongBaoMoi.LoaiTb,
            TieuDe = thongBaoMoi.TieuDe,
            NoiDung = thongBaoMoi.NoiDung,
            MucDo = thongBaoMoi.MucDo,
            NgayGui = thongBaoMoi.NgayGui,
            NgayHetHan = thongBaoMoi.NgayHetHan,
            IsActive = thongBaoMoi.IsActive
        };
    }

    public async Task CapNhatAsync(int id, ThongBaoCapNhatDTO dto)
    {
        var thongBao = await _donViCongViec.LayKhoLuuTru<ThongBao>().LayTheoIdAsync(id);
        if (thongBao == null)
            throw new KeyNotFoundException($"Không tìm thấy thông báo với ID: {id}");

        thongBao.LoaiTb = dto.LoaiThongBao;
        thongBao.TieuDe = dto.TieuDe;
        thongBao.NoiDung = dto.NoiDung;
        thongBao.MucDo = dto.MucDo;
        thongBao.NgayHetHan = dto.NgayHetHan;
        thongBao.IsActive = dto.IsActive;

        _donViCongViec.LayKhoLuuTru<ThongBao>().CapNhat(thongBao);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var thongBao = await _donViCongViec.LayKhoLuuTru<ThongBao>().LayTheoIdAsync(id);
        if (thongBao == null)
            throw new KeyNotFoundException($"Không tìm thấy thông báo với ID: {id}");

        _donViCongViec.LayKhoLuuTru<ThongBao>().Xoa(thongBao);
        await _donViCongViec.LuuThayDoiAsync();
    }
}

