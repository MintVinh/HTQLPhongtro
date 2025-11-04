using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class YeuCauSuaChuaService : IYeuCauSuaChuaService
{
    private readonly IDonViCongViec _donViCongViec;

    public YeuCauSuaChuaService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<YeuCauSuaChuaThongTinDTO>> LayTatCaAsync()
    {
        var danhSach = await _donViCongViec.LayKhoLuuTru<YeuCauSuaChua>().LayTatCaAsync();
        return danhSach.Select(y => new YeuCauSuaChuaThongTinDTO
        {
            MaYeuCau = y.IdYc,
            MaPhong = y.IdPhong,
            MaKhach = y.IdKhach,
            TieuDe = y.TieuDe,
            MoTa = y.MoTa,
            MucDo = y.MucDo,
            TrangThai = y.TrangThai,
            NgayYeuCau = y.NgayYeuCau,
            NgayXuLy = y.NgayXuLy,
            NgayHoanThanh = y.NgayHoanThanh,
            NguoiXuLy = y.NguoiXuLy,
            ChiPhi = y.ChiPhi,
            GhiChu = y.GhiChu
        });
    }

    public async Task<IEnumerable<YeuCauSuaChuaThongTinDTO>> TimKiemAsync(string? tuKhoa, string? trangThai)
    {
        tuKhoa = tuKhoa?.Trim();
        trangThai = trangThai?.Trim();
        IEnumerable<YeuCauSuaChua> danhSach;
        
        if (!string.IsNullOrWhiteSpace(tuKhoa) || !string.IsNullOrWhiteSpace(trangThai))
        {
            danhSach = await _donViCongViec
                .LayKhoLuuTru<YeuCauSuaChua>()
                .TimKiemAsync(y =>
                    (string.IsNullOrEmpty(tuKhoa) || 
                     y.TieuDe.Contains(tuKhoa) || 
                     y.MoTa.Contains(tuKhoa)) &&
                    (string.IsNullOrEmpty(trangThai) || y.TrangThai == trangThai)
                );
        }
        else
        {
            danhSach = await _donViCongViec.LayKhoLuuTru<YeuCauSuaChua>().LayTatCaAsync();
        }

        return danhSach.Select(y => new YeuCauSuaChuaThongTinDTO
        {
            MaYeuCau = y.IdYc,
            MaPhong = y.IdPhong,
            MaKhach = y.IdKhach,
            TieuDe = y.TieuDe,
            MoTa = y.MoTa,
            MucDo = y.MucDo,
            TrangThai = y.TrangThai,
            NgayYeuCau = y.NgayYeuCau,
            NgayXuLy = y.NgayXuLy,
            NgayHoanThanh = y.NgayHoanThanh,
            NguoiXuLy = y.NguoiXuLy,
            ChiPhi = y.ChiPhi,
            GhiChu = y.GhiChu
        });
    }

    public async Task<YeuCauSuaChuaThongTinDTO?> LayTheoIdAsync(int id)
    {
        var yeuCau = await _donViCongViec.LayKhoLuuTru<YeuCauSuaChua>().LayTheoIdAsync(id);
        if (yeuCau == null) return null;

        return new YeuCauSuaChuaThongTinDTO
        {
            MaYeuCau = yeuCau.IdYc,
            MaPhong = yeuCau.IdPhong,
            MaKhach = yeuCau.IdKhach,
            TieuDe = yeuCau.TieuDe,
            MoTa = yeuCau.MoTa,
            MucDo = yeuCau.MucDo,
            TrangThai = yeuCau.TrangThai,
            NgayYeuCau = yeuCau.NgayYeuCau,
            NgayXuLy = yeuCau.NgayXuLy,
            NgayHoanThanh = yeuCau.NgayHoanThanh,
            NguoiXuLy = yeuCau.NguoiXuLy,
            ChiPhi = yeuCau.ChiPhi,
            GhiChu = yeuCau.GhiChu
        };
    }

    public async Task<YeuCauSuaChuaThongTinDTO> TaoMoiAsync(YeuCauSuaChuaTaoDTO dto)
    {
        var yeuCauMoi = new YeuCauSuaChua
        {
            IdPhong = dto.MaPhong,
            IdKhach = dto.MaKhach,
            TieuDe = dto.TieuDe,
            MoTa = dto.MoTa,
            MucDo = dto.MucDo,
            TrangThai = "Pending",
            NgayYeuCau = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<YeuCauSuaChua>().ThemMoiAsync(yeuCauMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new YeuCauSuaChuaThongTinDTO
        {
            MaYeuCau = yeuCauMoi.IdYc,
            MaPhong = yeuCauMoi.IdPhong,
            MaKhach = yeuCauMoi.IdKhach,
            TieuDe = yeuCauMoi.TieuDe,
            MoTa = yeuCauMoi.MoTa,
            MucDo = yeuCauMoi.MucDo,
            TrangThai = yeuCauMoi.TrangThai,
            NgayYeuCau = yeuCauMoi.NgayYeuCau,
            NgayXuLy = yeuCauMoi.NgayXuLy,
            NgayHoanThanh = yeuCauMoi.NgayHoanThanh,
            NguoiXuLy = yeuCauMoi.NguoiXuLy,
            ChiPhi = yeuCauMoi.ChiPhi,
            GhiChu = yeuCauMoi.GhiChu
        };
    }

    public async Task CapNhatAsync(int id, YeuCauSuaChuaCapNhatDTO dto)
    {
        var yeuCau = await _donViCongViec.LayKhoLuuTru<YeuCauSuaChua>().LayTheoIdAsync(id);
        if (yeuCau == null)
            throw new KeyNotFoundException($"Không tìm thấy yêu cầu sửa chữa với ID: {id}");

        if (!string.IsNullOrEmpty(dto.TieuDe)) yeuCau.TieuDe = dto.TieuDe;
        if (!string.IsNullOrEmpty(dto.MoTa)) yeuCau.MoTa = dto.MoTa;
        if (!string.IsNullOrEmpty(dto.MucDo)) yeuCau.MucDo = dto.MucDo;
        yeuCau.TrangThai = dto.TrangThai;
        yeuCau.NgayXuLy = dto.NgayXuLy;
        yeuCau.NgayHoanThanh = dto.NgayHoanThanh;
        yeuCau.NguoiXuLy = dto.NguoiXuLy;
        yeuCau.ChiPhi = dto.ChiPhi;
        yeuCau.GhiChu = dto.GhiChu;
        yeuCau.UpdatedAt = DateTime.UtcNow;

        _donViCongViec.LayKhoLuuTru<YeuCauSuaChua>().CapNhat(yeuCau);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var yeuCau = await _donViCongViec.LayKhoLuuTru<YeuCauSuaChua>().LayTheoIdAsync(id);
        if (yeuCau == null)
            throw new KeyNotFoundException($"Không tìm thấy yêu cầu sửa chữa với ID: {id}");

        _donViCongViec.LayKhoLuuTru<YeuCauSuaChua>().Xoa(yeuCau);
        await _donViCongViec.LuuThayDoiAsync();
    }
}

