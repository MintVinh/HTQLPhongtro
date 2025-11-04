using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class ChiSoDienNuocService : IChiSoDienNuocService
{
    private readonly IDonViCongViec _donViCongViec;

    public ChiSoDienNuocService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<ChiSoDienNuocThongTinDTO>> LayTatCaAsync()
    {
        var danhSach = await _donViCongViec.LayKhoLuuTru<ChiSoDienNuoc>().LayTatCaAsync();
        return danhSach.Select(c => new ChiSoDienNuocThongTinDTO
        {
            MaChiSo = c.IdCs,
            MaPhong = c.IdPhong,
            Thang = c.Thang,
            Nam = c.Nam,
            ChiSoDienCu = c.ChiSoDienCu,
            ChiSoDienMoi = c.ChiSoDienMoi,
            TieuThuDien = c.TieuThuDien,
            ChiSoNuocCu = c.ChiSoNuocCu,
            ChiSoNuocMoi = c.ChiSoNuocMoi,
            TieuThuNuoc = c.TieuThuNuoc,
            NgayGhi = c.NgayGhi,
            NguoiGhi = c.NguoiGhi,
            GhiChu = c.GhiChu
        });
    }

    public async Task<IEnumerable<ChiSoDienNuocThongTinDTO>> TimKiemAsync(int? maPhong, int? thang, int? nam)
    {
        IEnumerable<ChiSoDienNuoc> danhSach;
        
        if (maPhong.HasValue || thang.HasValue || nam.HasValue)
        {
            danhSach = await _donViCongViec
                .LayKhoLuuTru<ChiSoDienNuoc>()
                .TimKiemAsync(c =>
                    (!maPhong.HasValue || c.IdPhong == maPhong.Value) &&
                    (!thang.HasValue || c.Thang == thang.Value) &&
                    (!nam.HasValue || c.Nam == nam.Value)
                );
        }
        else
        {
            danhSach = await _donViCongViec.LayKhoLuuTru<ChiSoDienNuoc>().LayTatCaAsync();
        }

        return danhSach.Select(c => new ChiSoDienNuocThongTinDTO
        {
            MaChiSo = c.IdCs,
            MaPhong = c.IdPhong,
            Thang = c.Thang,
            Nam = c.Nam,
            ChiSoDienCu = c.ChiSoDienCu,
            ChiSoDienMoi = c.ChiSoDienMoi,
            TieuThuDien = c.TieuThuDien,
            ChiSoNuocCu = c.ChiSoNuocCu,
            ChiSoNuocMoi = c.ChiSoNuocMoi,
            TieuThuNuoc = c.TieuThuNuoc,
            NgayGhi = c.NgayGhi,
            NguoiGhi = c.NguoiGhi,
            GhiChu = c.GhiChu
        });
    }

    public async Task<ChiSoDienNuocThongTinDTO?> LayTheoIdAsync(int id)
    {
        var chiSo = await _donViCongViec.LayKhoLuuTru<ChiSoDienNuoc>().LayTheoIdAsync(id);
        if (chiSo == null) return null;

        return new ChiSoDienNuocThongTinDTO
        {
            MaChiSo = chiSo.IdCs,
            MaPhong = chiSo.IdPhong,
            Thang = chiSo.Thang,
            Nam = chiSo.Nam,
            ChiSoDienCu = chiSo.ChiSoDienCu,
            ChiSoDienMoi = chiSo.ChiSoDienMoi,
            TieuThuDien = chiSo.TieuThuDien,
            ChiSoNuocCu = chiSo.ChiSoNuocCu,
            ChiSoNuocMoi = chiSo.ChiSoNuocMoi,
            TieuThuNuoc = chiSo.TieuThuNuoc,
            NgayGhi = chiSo.NgayGhi,
            NguoiGhi = chiSo.NguoiGhi,
            GhiChu = chiSo.GhiChu
        };
    }

    public async Task<ChiSoDienNuocThongTinDTO> TaoMoiAsync(ChiSoDienNuocTaoDTO dto)
    {
        var tieuThuDien = dto.ChiSoDienMoi - dto.ChiSoDienCu;
        var tieuThuNuoc = dto.ChiSoNuocMoi - dto.ChiSoNuocCu;

        var chiSoMoi = new ChiSoDienNuoc
        {
            IdPhong = dto.MaPhong,
            Thang = dto.Thang,
            Nam = dto.Nam,
            ChiSoDienCu = dto.ChiSoDienCu,
            ChiSoDienMoi = dto.ChiSoDienMoi,
            TieuThuDien = tieuThuDien,
            ChiSoNuocCu = dto.ChiSoNuocCu,
            ChiSoNuocMoi = dto.ChiSoNuocMoi,
            TieuThuNuoc = tieuThuNuoc,
            NgayGhi = dto.NgayGhi,
            NguoiGhi = dto.NguoiGhi,
            GhiChu = dto.GhiChu,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<ChiSoDienNuoc>().ThemMoiAsync(chiSoMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new ChiSoDienNuocThongTinDTO
        {
            MaChiSo = chiSoMoi.IdCs,
            MaPhong = chiSoMoi.IdPhong,
            Thang = chiSoMoi.Thang,
            Nam = chiSoMoi.Nam,
            ChiSoDienCu = chiSoMoi.ChiSoDienCu,
            ChiSoDienMoi = chiSoMoi.ChiSoDienMoi,
            TieuThuDien = chiSoMoi.TieuThuDien,
            ChiSoNuocCu = chiSoMoi.ChiSoNuocCu,
            ChiSoNuocMoi = chiSoMoi.ChiSoNuocMoi,
            TieuThuNuoc = chiSoMoi.TieuThuNuoc,
            NgayGhi = chiSoMoi.NgayGhi,
            NguoiGhi = chiSoMoi.NguoiGhi,
            GhiChu = chiSoMoi.GhiChu
        };
    }

    public async Task CapNhatAsync(int id, ChiSoDienNuocCapNhatDTO dto)
    {
        var chiSo = await _donViCongViec.LayKhoLuuTru<ChiSoDienNuoc>().LayTheoIdAsync(id);
        if (chiSo == null)
            throw new KeyNotFoundException($"Không tìm thấy chỉ số điện nước với ID: {id}");

        var tieuThuDien = dto.ChiSoDienMoi - chiSo.ChiSoDienCu;
        var tieuThuNuoc = dto.ChiSoNuocMoi - chiSo.ChiSoNuocCu;

        chiSo.ChiSoDienMoi = dto.ChiSoDienMoi;
        chiSo.TieuThuDien = tieuThuDien;
        chiSo.ChiSoNuocMoi = dto.ChiSoNuocMoi;
        chiSo.TieuThuNuoc = tieuThuNuoc;
        chiSo.NgayGhi = dto.NgayGhi;
        chiSo.NguoiGhi = dto.NguoiGhi;
        chiSo.GhiChu = dto.GhiChu;

        _donViCongViec.LayKhoLuuTru<ChiSoDienNuoc>().CapNhat(chiSo);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var chiSo = await _donViCongViec.LayKhoLuuTru<ChiSoDienNuoc>().LayTheoIdAsync(id);
        if (chiSo == null)
            throw new KeyNotFoundException($"Không tìm thấy chỉ số điện nước với ID: {id}");

        _donViCongViec.LayKhoLuuTru<ChiSoDienNuoc>().Xoa(chiSo);
        await _donViCongViec.LuuThayDoiAsync();
    }
}

