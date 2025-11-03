using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class QuanLyPhongService : IQuanLyPhongService
{
    private readonly IDonViCongViec _donViCongViec;

    public QuanLyPhongService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<ThongTinPhongDTO>> LayTatCaPhongAsync()
    {
        var danhSachPhong = await _donViCongViec.LayKhoLuuTru<Phong>().LayTatCaAsync();
        return danhSachPhong.Select(p => new ThongTinPhongDTO
        {
            MaPhong = p.IdPhong,
            TenPhong = p.TenPhong,
            Tang = p.Tang,
            DienTich = p.DienTich,
            GiaThue = p.GiaThue,
            SoNguoiToiDa = p.SoNguoiToiDa,
            TrangThai = p.TrangThai,
            MoTa = p.MoTa
        });
    }

    public async Task<IEnumerable<ThongTinPhongDTO>> TimKiemPhongAsync(string? tuKhoa, string? trangThai)
    {
        tuKhoa = tuKhoa?.Trim();
        trangThai = trangThai?.Trim();
        IEnumerable<Phong> danhSach;
        if (!string.IsNullOrWhiteSpace(tuKhoa) || !string.IsNullOrWhiteSpace(trangThai))
        {
            danhSach = await _donViCongViec
                .LayKhoLuuTru<Phong>()
                .TimKiemAsync(p =>
                    (string.IsNullOrEmpty(tuKhoa) || p.TenPhong.Contains(tuKhoa)) &&
                    (string.IsNullOrEmpty(trangThai) || p.TrangThai == trangThai)
                );
        }
        else
        {
            danhSach = await _donViCongViec.LayKhoLuuTru<Phong>().LayTatCaAsync();
        }

        return danhSach.Select(p => new ThongTinPhongDTO
        {
            MaPhong = p.IdPhong,
            TenPhong = p.TenPhong,
            Tang = p.Tang,
            DienTich = p.DienTich,
            GiaThue = p.GiaThue,
            SoNguoiToiDa = p.SoNguoiToiDa,
            TrangThai = p.TrangThai,
            MoTa = p.MoTa
        });
    }

    public async Task<ThongTinPhongDTO?> LayPhongTheoIdAsync(int id)
    {
        var phong = await _donViCongViec.LayKhoLuuTru<Phong>().LayTheoIdAsync(id);
        if (phong == null) return null;

        return new ThongTinPhongDTO
        {
            MaPhong = phong.IdPhong,
            TenPhong = phong.TenPhong,
            Tang = phong.Tang,
            DienTich = phong.DienTich,
            GiaThue = phong.GiaThue,
            SoNguoiToiDa = phong.SoNguoiToiDa,
            TrangThai = phong.TrangThai,
            MoTa = phong.MoTa
        };
    }

    public async Task<ThongTinPhongDTO> TaoPhongMoiAsync(TaoPhongMoiDTO taoPhongDto)
    {
        var phongMoi = new Phong
        {
            IdChu = taoPhongDto.MaChuTro,
            IdLoai = taoPhongDto.MaLoaiPhong,
            TenPhong = taoPhongDto.TenPhong,
            Tang = taoPhongDto.Tang,
            DienTich = taoPhongDto.DienTich,
            GiaThue = taoPhongDto.GiaThue,
            SoNguoiToiDa = taoPhongDto.SoNguoiToiDa,
            TrangThai = "Trống",
            MoTa = taoPhongDto.MoTa,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<Phong>().ThemMoiAsync(phongMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new ThongTinPhongDTO
        {
            MaPhong = phongMoi.IdPhong,
            TenPhong = phongMoi.TenPhong,
            Tang = phongMoi.Tang,
            DienTich = phongMoi.DienTich,
            GiaThue = phongMoi.GiaThue,
            SoNguoiToiDa = phongMoi.SoNguoiToiDa,
            TrangThai = phongMoi.TrangThai,
            MoTa = phongMoi.MoTa
        };
    }

    public async Task CapNhatPhongAsync(int id, CapNhatPhongDTO capNhatPhongDto)
    {
        var phong = await _donViCongViec.LayKhoLuuTru<Phong>().LayTheoIdAsync(id);
        if (phong == null)
            throw new KeyNotFoundException($"Không tìm thấy phòng với ID: {id}");

        phong.TenPhong = capNhatPhongDto.TenPhong;
        phong.GiaThue = capNhatPhongDto.GiaThue;
        phong.SoNguoiToiDa = capNhatPhongDto.SoNguoiToiDa;
        phong.MoTa = capNhatPhongDto.MoTa;
        phong.UpdatedAt = DateTime.UtcNow;

        _donViCongViec.LayKhoLuuTru<Phong>().CapNhat(phong);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaPhongAsync(int id)
    {
        var phong = await _donViCongViec.LayKhoLuuTru<Phong>().LayTheoIdAsync(id);
        if (phong == null)
            throw new KeyNotFoundException($"Không tìm thấy phòng với ID: {id}");

        _donViCongViec.LayKhoLuuTru<Phong>().Xoa(phong);
        await _donViCongViec.LuuThayDoiAsync();
    }
}
