using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class HoaDonThueService : IHoaDonThueService
{
    private readonly IDonViCongViec _donViCongViec;

    public HoaDonThueService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<HoaDonThueThongTinDTO>> LayTatCaAsync()
    {
        var danhSach = await _donViCongViec.LayKhoLuuTru<HoaDonThue>().LayTatCaAsync();
        return danhSach.Select(h => new HoaDonThueThongTinDTO
        {
            MaHoaDon = h.IdHdThue,
            MaHopDong = h.IdHd,
            MaChiSo = h.IdCs,
            MaHoaDonString = h.MaHoaDon,
            Thang = h.Thang,
            Nam = h.Nam,
            TienPhong = h.TienPhong,
            TienDien = h.TienDien,
            TienNuoc = h.TienNuoc,
            TienMang = h.TienMang,
            TienRac = h.TienRac,
            TienGuiXe = h.TienGuiXe,
            TienPhat = h.TienPhat,
            GiamGia = h.GiamGia,
            TongTien = h.TongTien,
            HanThanhToan = h.HanThanhToan,
            NgayThanhToan = h.NgayThanhToan,
            TrangThai = h.TrangThai,
            GhiChu = h.GhiChu
        });
    }

    public async Task<IEnumerable<HoaDonThueThongTinDTO>> TimKiemAsync(int? maHopDong, int? thang, int? nam, string? trangThai)
    {
        trangThai = trangThai?.Trim();
        IEnumerable<HoaDonThue> danhSach;
        
        if (maHopDong.HasValue || thang.HasValue || nam.HasValue || !string.IsNullOrWhiteSpace(trangThai))
        {
            danhSach = await _donViCongViec
                .LayKhoLuuTru<HoaDonThue>()
                .TimKiemAsync(h =>
                    (!maHopDong.HasValue || h.IdHd == maHopDong.Value) &&
                    (!thang.HasValue || h.Thang == thang.Value) &&
                    (!nam.HasValue || h.Nam == nam.Value) &&
                    (string.IsNullOrEmpty(trangThai) || h.TrangThai == trangThai)
                );
        }
        else
        {
            danhSach = await _donViCongViec.LayKhoLuuTru<HoaDonThue>().LayTatCaAsync();
        }

        return danhSach.Select(h => new HoaDonThueThongTinDTO
        {
            MaHoaDon = h.IdHdThue,
            MaHopDong = h.IdHd,
            MaChiSo = h.IdCs,
            MaHoaDonString = h.MaHoaDon,
            Thang = h.Thang,
            Nam = h.Nam,
            TienPhong = h.TienPhong,
            TienDien = h.TienDien,
            TienNuoc = h.TienNuoc,
            TienMang = h.TienMang,
            TienRac = h.TienRac,
            TienGuiXe = h.TienGuiXe,
            TienPhat = h.TienPhat,
            GiamGia = h.GiamGia,
            TongTien = h.TongTien,
            HanThanhToan = h.HanThanhToan,
            NgayThanhToan = h.NgayThanhToan,
            TrangThai = h.TrangThai,
            GhiChu = h.GhiChu
        });
    }

    public async Task<HoaDonThueThongTinDTO?> LayTheoIdAsync(int id)
    {
        var hoaDon = await _donViCongViec.LayKhoLuuTru<HoaDonThue>().LayTheoIdAsync(id);
        if (hoaDon == null) return null;

        return new HoaDonThueThongTinDTO
        {
            MaHoaDon = hoaDon.IdHdThue,
            MaHopDong = hoaDon.IdHd,
            MaChiSo = hoaDon.IdCs,
            MaHoaDonString = hoaDon.MaHoaDon,
            Thang = hoaDon.Thang,
            Nam = hoaDon.Nam,
            TienPhong = hoaDon.TienPhong,
            TienDien = hoaDon.TienDien,
            TienNuoc = hoaDon.TienNuoc,
            TienMang = hoaDon.TienMang,
            TienRac = hoaDon.TienRac,
            TienGuiXe = hoaDon.TienGuiXe,
            TienPhat = hoaDon.TienPhat,
            GiamGia = hoaDon.GiamGia,
            TongTien = hoaDon.TongTien,
            HanThanhToan = hoaDon.HanThanhToan,
            NgayThanhToan = hoaDon.NgayThanhToan,
            TrangThai = hoaDon.TrangThai,
            GhiChu = hoaDon.GhiChu
        };
    }

    public async Task<HoaDonThueThongTinDTO> TaoMoiAsync(HoaDonThueTaoDTO dto)
    {
        var tongTien = dto.TienPhong + dto.TienDien + dto.TienNuoc + dto.TienMang + 
                      dto.TienRac + dto.TienGuiXe + dto.TienPhat - dto.GiamGia;

        var hoaDonMoi = new HoaDonThue
        {
            IdHd = dto.MaHopDong,
            IdCs = dto.MaChiSo,
            MaHoaDon = dto.MaHoaDonString,
            Thang = dto.Thang,
            Nam = dto.Nam,
            TienPhong = dto.TienPhong,
            TienDien = dto.TienDien,
            TienNuoc = dto.TienNuoc,
            TienMang = dto.TienMang,
            TienRac = dto.TienRac,
            TienGuiXe = dto.TienGuiXe,
            TienPhat = dto.TienPhat,
            GiamGia = dto.GiamGia,
            TongTien = tongTien,
            HanThanhToan = dto.HanThanhToan,
            TrangThai = "Unpaid",
            GhiChu = dto.GhiChu,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<HoaDonThue>().ThemMoiAsync(hoaDonMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new HoaDonThueThongTinDTO
        {
            MaHoaDon = hoaDonMoi.IdHdThue,
            MaHopDong = hoaDonMoi.IdHd,
            MaChiSo = hoaDonMoi.IdCs,
            MaHoaDonString = hoaDonMoi.MaHoaDon,
            Thang = hoaDonMoi.Thang,
            Nam = hoaDonMoi.Nam,
            TienPhong = hoaDonMoi.TienPhong,
            TienDien = hoaDonMoi.TienDien,
            TienNuoc = hoaDonMoi.TienNuoc,
            TienMang = hoaDonMoi.TienMang,
            TienRac = hoaDonMoi.TienRac,
            TienGuiXe = hoaDonMoi.TienGuiXe,
            TienPhat = hoaDonMoi.TienPhat,
            GiamGia = hoaDonMoi.GiamGia,
            TongTien = hoaDonMoi.TongTien,
            HanThanhToan = hoaDonMoi.HanThanhToan,
            NgayThanhToan = hoaDonMoi.NgayThanhToan,
            TrangThai = hoaDonMoi.TrangThai,
            GhiChu = hoaDonMoi.GhiChu
        };
    }

    public async Task CapNhatAsync(int id, HoaDonThueCapNhatDTO dto)
    {
        var hoaDon = await _donViCongViec.LayKhoLuuTru<HoaDonThue>().LayTheoIdAsync(id);
        if (hoaDon == null)
            throw new KeyNotFoundException($"Không tìm thấy hóa đơn thuê với ID: {id}");

        if (dto.TienPhong.HasValue) hoaDon.TienPhong = dto.TienPhong.Value;
        if (dto.TienDien.HasValue) hoaDon.TienDien = dto.TienDien.Value;
        if (dto.TienNuoc.HasValue) hoaDon.TienNuoc = dto.TienNuoc.Value;
        if (dto.TienMang.HasValue) hoaDon.TienMang = dto.TienMang.Value;
        if (dto.TienRac.HasValue) hoaDon.TienRac = dto.TienRac.Value;
        if (dto.TienGuiXe.HasValue) hoaDon.TienGuiXe = dto.TienGuiXe.Value;
        if (dto.TienPhat.HasValue) hoaDon.TienPhat = dto.TienPhat.Value;
        if (dto.GiamGia.HasValue) hoaDon.GiamGia = dto.GiamGia.Value;
        
        hoaDon.TongTien = hoaDon.TienPhong + hoaDon.TienDien + hoaDon.TienNuoc + 
                         hoaDon.TienMang + hoaDon.TienRac + hoaDon.TienGuiXe + 
                         hoaDon.TienPhat - hoaDon.GiamGia;
        
        hoaDon.TrangThai = dto.TrangThai;
        hoaDon.NgayThanhToan = dto.NgayThanhToan;
        hoaDon.GhiChu = dto.GhiChu;
        hoaDon.UpdatedAt = DateTime.UtcNow;

        _donViCongViec.LayKhoLuuTru<HoaDonThue>().CapNhat(hoaDon);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var hoaDon = await _donViCongViec.LayKhoLuuTru<HoaDonThue>().LayTheoIdAsync(id);
        if (hoaDon == null)
            throw new KeyNotFoundException($"Không tìm thấy hóa đơn thuê với ID: {id}");

        _donViCongViec.LayKhoLuuTru<HoaDonThue>().Xoa(hoaDon);
        await _donViCongViec.LuuThayDoiAsync();
    }
}

