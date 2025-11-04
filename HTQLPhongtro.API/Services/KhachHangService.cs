using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class KhachHangService : IKhachHangService
{
    private readonly IDonViCongViec _donViCongViec;

    public KhachHangService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<KhachHangThongTinDTO>> LayTatCaAsync()
    {
        var danhSach = await _donViCongViec.LayKhoLuuTru<KhachHang>().LayTatCaAsync();
        return danhSach.Select(k => new KhachHangThongTinDTO
        {
            MaKhach = k.IdKhach,
            MaTaiKhoan = k.IdTk,
            HoTen = k.HoTen,
            Cccd = k.Cccd,
            Sdt = k.Sdt,
            Email = k.Email,
            DiaChi = k.DiaChi,
            NgaySinh = k.NgaySinh,
            NgheNghiep = k.NgheNghiep,
            TrangThai = k.TrangThai,
            GhiChu = k.GhiChu
        });
    }

    public async Task<IEnumerable<KhachHangThongTinDTO>> TimKiemAsync(string? tuKhoa, string? trangThai)
    {
        tuKhoa = tuKhoa?.Trim();
        trangThai = trangThai?.Trim();
        IEnumerable<KhachHang> danhSach;
        
        if (!string.IsNullOrWhiteSpace(tuKhoa) || !string.IsNullOrWhiteSpace(trangThai))
        {
            danhSach = await _donViCongViec
                .LayKhoLuuTru<KhachHang>()
                .TimKiemAsync(k =>
                    (string.IsNullOrEmpty(tuKhoa) || 
                     k.HoTen.Contains(tuKhoa) || 
                     k.Sdt.Contains(tuKhoa) || 
                     k.Cccd.Contains(tuKhoa) ||
                     (k.Email != null && k.Email.Contains(tuKhoa))) &&
                    (string.IsNullOrEmpty(trangThai) || k.TrangThai == trangThai)
                );
        }
        else
        {
            danhSach = await _donViCongViec.LayKhoLuuTru<KhachHang>().LayTatCaAsync();
        }

        return danhSach.Select(k => new KhachHangThongTinDTO
        {
            MaKhach = k.IdKhach,
            MaTaiKhoan = k.IdTk,
            HoTen = k.HoTen,
            Cccd = k.Cccd,
            Sdt = k.Sdt,
            Email = k.Email,
            DiaChi = k.DiaChi,
            NgaySinh = k.NgaySinh,
            NgheNghiep = k.NgheNghiep,
            TrangThai = k.TrangThai,
            GhiChu = k.GhiChu
        });
    }

    public async Task<KhachHangThongTinDTO?> LayTheoIdAsync(int id)
    {
        var khachHang = await _donViCongViec.LayKhoLuuTru<KhachHang>().LayTheoIdAsync(id);
        if (khachHang == null) return null;

        return new KhachHangThongTinDTO
        {
            MaKhach = khachHang.IdKhach,
            MaTaiKhoan = khachHang.IdTk,
            HoTen = khachHang.HoTen,
            Cccd = khachHang.Cccd,
            Sdt = khachHang.Sdt,
            Email = khachHang.Email,
            DiaChi = khachHang.DiaChi,
            NgaySinh = khachHang.NgaySinh,
            NgheNghiep = khachHang.NgheNghiep,
            TrangThai = khachHang.TrangThai,
            GhiChu = khachHang.GhiChu
        };
    }

    public async Task<KhachHangThongTinDTO> TaoMoiAsync(KhachHangTaoDTO dto)
    {
        var khachHangMoi = new KhachHang
        {
            IdTk = dto.MaTaiKhoan,
            HoTen = dto.HoTen,
            Cccd = dto.Cccd,
            Sdt = dto.Sdt,
            Email = dto.Email,
            DiaChi = dto.DiaChi,
            NgaySinh = dto.NgaySinh,
            NgheNghiep = dto.NgheNghiep,
            TrangThai = "Active",
            GhiChu = dto.GhiChu,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<KhachHang>().ThemMoiAsync(khachHangMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new KhachHangThongTinDTO
        {
            MaKhach = khachHangMoi.IdKhach,
            MaTaiKhoan = khachHangMoi.IdTk,
            HoTen = khachHangMoi.HoTen,
            Cccd = khachHangMoi.Cccd,
            Sdt = khachHangMoi.Sdt,
            Email = khachHangMoi.Email,
            DiaChi = khachHangMoi.DiaChi,
            NgaySinh = khachHangMoi.NgaySinh,
            NgheNghiep = khachHangMoi.NgheNghiep,
            TrangThai = khachHangMoi.TrangThai,
            GhiChu = khachHangMoi.GhiChu
        };
    }

    public async Task CapNhatAsync(int id, KhachHangCapNhatDTO dto)
    {
        var khachHang = await _donViCongViec.LayKhoLuuTru<KhachHang>().LayTheoIdAsync(id);
        if (khachHang == null)
            throw new KeyNotFoundException($"Không tìm thấy khách hàng với ID: {id}");

        khachHang.IdTk = dto.MaTaiKhoan;
        khachHang.HoTen = dto.HoTen;
        khachHang.Cccd = dto.Cccd;
        khachHang.Sdt = dto.Sdt;
        khachHang.Email = dto.Email;
        khachHang.DiaChi = dto.DiaChi;
        khachHang.NgaySinh = dto.NgaySinh;
        khachHang.NgheNghiep = dto.NgheNghiep;
        khachHang.TrangThai = dto.TrangThai;
        khachHang.GhiChu = dto.GhiChu;
        khachHang.UpdatedAt = DateTime.UtcNow;

        _donViCongViec.LayKhoLuuTru<KhachHang>().CapNhat(khachHang);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var khachHang = await _donViCongViec.LayKhoLuuTru<KhachHang>().LayTheoIdAsync(id);
        if (khachHang == null)
            throw new KeyNotFoundException($"Không tìm thấy khách hàng với ID: {id}");

        _donViCongViec.LayKhoLuuTru<KhachHang>().Xoa(khachHang);
        await _donViCongViec.LuuThayDoiAsync();
    }
}

