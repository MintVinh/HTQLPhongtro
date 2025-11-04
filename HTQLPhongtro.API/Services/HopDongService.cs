using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class HopDongService : IHopDongService
{
    private readonly IDonViCongViec _donViCongViec;

    public HopDongService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<HopDongThongTinDTO>> LayTatCaAsync()
    {
        var danhSach = await _donViCongViec.LayKhoLuuTru<HopDong>().LayTatCaAsync();
        return danhSach.Select(h => new HopDongThongTinDTO
        {
            MaHopDong = h.IdHd,
            MaPhong = h.IdPhong,
            MaKhach = h.IdKhach,
            MaDatCoc = h.IdCoc,
            MaHopDongString = h.MaHopDong,
            NgayBatDau = h.NgayBatDau,
            NgayKetThuc = h.NgayKetThuc,
            TienCoc = h.TienCoc,
            GiaThue = h.GiaThue,
            ChuKyThanhToan = h.ChuKyThanhToan,
            NgayThanhToan = h.NgayThanhToan,
            TrangThai = h.TrangThai,
            GhiChu = h.GhiChu,
            FileDinhKem = h.FileDinhKem
        });
    }

    public async Task<IEnumerable<HopDongThongTinDTO>> TimKiemAsync(string? tuKhoa, string? trangThai)
    {
        tuKhoa = tuKhoa?.Trim();
        trangThai = trangThai?.Trim();
        IEnumerable<HopDong> danhSach;
        
        if (!string.IsNullOrWhiteSpace(tuKhoa) || !string.IsNullOrWhiteSpace(trangThai))
        {
            danhSach = await _donViCongViec
                .LayKhoLuuTru<HopDong>()
                .TimKiemAsync(h =>
                    (string.IsNullOrEmpty(tuKhoa) || h.MaHopDong.Contains(tuKhoa)) &&
                    (string.IsNullOrEmpty(trangThai) || h.TrangThai == trangThai)
                );
        }
        else
        {
            danhSach = await _donViCongViec.LayKhoLuuTru<HopDong>().LayTatCaAsync();
        }

        return danhSach.Select(h => new HopDongThongTinDTO
        {
            MaHopDong = h.IdHd,
            MaPhong = h.IdPhong,
            MaKhach = h.IdKhach,
            MaDatCoc = h.IdCoc,
            MaHopDongString = h.MaHopDong,
            NgayBatDau = h.NgayBatDau,
            NgayKetThuc = h.NgayKetThuc,
            TienCoc = h.TienCoc,
            GiaThue = h.GiaThue,
            ChuKyThanhToan = h.ChuKyThanhToan,
            NgayThanhToan = h.NgayThanhToan,
            TrangThai = h.TrangThai,
            GhiChu = h.GhiChu,
            FileDinhKem = h.FileDinhKem
        });
    }

    public async Task<HopDongThongTinDTO?> LayTheoIdAsync(int id)
    {
        var hopDong = await _donViCongViec.LayKhoLuuTru<HopDong>().LayTheoIdAsync(id);
        if (hopDong == null) return null;

        return new HopDongThongTinDTO
        {
            MaHopDong = hopDong.IdHd,
            MaPhong = hopDong.IdPhong,
            MaKhach = hopDong.IdKhach,
            MaDatCoc = hopDong.IdCoc,
            MaHopDongString = hopDong.MaHopDong,
            NgayBatDau = hopDong.NgayBatDau,
            NgayKetThuc = hopDong.NgayKetThuc,
            TienCoc = hopDong.TienCoc,
            GiaThue = hopDong.GiaThue,
            ChuKyThanhToan = hopDong.ChuKyThanhToan,
            NgayThanhToan = hopDong.NgayThanhToan,
            TrangThai = hopDong.TrangThai,
            GhiChu = hopDong.GhiChu,
            FileDinhKem = hopDong.FileDinhKem
        };
    }

    public async Task<HopDongThongTinDTO> TaoMoiAsync(HopDongTaoDTO dto)
    {
        var hopDongMoi = new HopDong
        {
            IdPhong = dto.MaPhong,
            IdKhach = dto.MaKhach,
            IdCoc = dto.MaDatCoc,
            MaHopDong = dto.MaHopDongString,
            NgayBatDau = dto.NgayBatDau,
            NgayKetThuc = dto.NgayKetThuc,
            TienCoc = dto.TienCoc,
            GiaThue = dto.GiaThue,
            ChuKyThanhToan = dto.ChuKyThanhToan,
            NgayThanhToan = dto.NgayThanhToan,
            TrangThai = "Active",
            GhiChu = dto.GhiChu,
            FileDinhKem = dto.FileDinhKem,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<HopDong>().ThemMoiAsync(hopDongMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new HopDongThongTinDTO
        {
            MaHopDong = hopDongMoi.IdHd,
            MaPhong = hopDongMoi.IdPhong,
            MaKhach = hopDongMoi.IdKhach,
            MaDatCoc = hopDongMoi.IdCoc,
            MaHopDongString = hopDongMoi.MaHopDong,
            NgayBatDau = hopDongMoi.NgayBatDau,
            NgayKetThuc = hopDongMoi.NgayKetThuc,
            TienCoc = hopDongMoi.TienCoc,
            GiaThue = hopDongMoi.GiaThue,
            ChuKyThanhToan = hopDongMoi.ChuKyThanhToan,
            NgayThanhToan = hopDongMoi.NgayThanhToan,
            TrangThai = hopDongMoi.TrangThai,
            GhiChu = hopDongMoi.GhiChu,
            FileDinhKem = hopDongMoi.FileDinhKem
        };
    }

    public async Task CapNhatAsync(int id, HopDongCapNhatDTO dto)
    {
        var hopDong = await _donViCongViec.LayKhoLuuTru<HopDong>().LayTheoIdAsync(id);
        if (hopDong == null)
            throw new KeyNotFoundException($"Không tìm thấy hợp đồng với ID: {id}");

        hopDong.NgayKetThuc = dto.NgayKetThuc;
        hopDong.GiaThue = dto.GiaThue;
        hopDong.ChuKyThanhToan = dto.ChuKyThanhToan;
        hopDong.NgayThanhToan = dto.NgayThanhToan;
        hopDong.TrangThai = dto.TrangThai;
        hopDong.GhiChu = dto.GhiChu;
        hopDong.FileDinhKem = dto.FileDinhKem;
        hopDong.UpdatedAt = DateTime.UtcNow;

        _donViCongViec.LayKhoLuuTru<HopDong>().CapNhat(hopDong);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var hopDong = await _donViCongViec.LayKhoLuuTru<HopDong>().LayTheoIdAsync(id);
        if (hopDong == null)
            throw new KeyNotFoundException($"Không tìm thấy hợp đồng với ID: {id}");

        _donViCongViec.LayKhoLuuTru<HopDong>().Xoa(hopDong);
        await _donViCongViec.LuuThayDoiAsync();
    }
}

