using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class PhieuPhatService : IPhieuPhatService
{
    private readonly IDonViCongViec _donViCongViec;

    public PhieuPhatService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<PhieuPhatThongTinDTO>> LayTatCaAsync()
    {
        var danhSach = await _donViCongViec.LayKhoLuuTru<PhieuPhat>().LayTatCaAsync();
        return danhSach.Select(p => new PhieuPhatThongTinDTO
        {
            MaPhieuPhat = p.IdPhat,
            MaHopDong = p.IdHd,
            MaQuyDinhPhat = p.IdQdp,
            LyDo = p.LyDo,
            SoTien = p.SoTien,
            NgayPhat = p.NgayPhat,
            TrangThai = p.TrangThai,
            NgayThanhToan = p.NgayThanhToan,
            GhiChu = p.GhiChu
        });
    }

    public async Task<IEnumerable<PhieuPhatThongTinDTO>> TimKiemAsync(int? maHopDong, string? trangThai)
    {
        trangThai = trangThai?.Trim();
        IEnumerable<PhieuPhat> danhSach;
        
        if (maHopDong.HasValue || !string.IsNullOrWhiteSpace(trangThai))
        {
            danhSach = await _donViCongViec
                .LayKhoLuuTru<PhieuPhat>()
                .TimKiemAsync(p =>
                    (!maHopDong.HasValue || p.IdHd == maHopDong.Value) &&
                    (string.IsNullOrEmpty(trangThai) || p.TrangThai == trangThai)
                );
        }
        else
        {
            danhSach = await _donViCongViec.LayKhoLuuTru<PhieuPhat>().LayTatCaAsync();
        }

        return danhSach.Select(p => new PhieuPhatThongTinDTO
        {
            MaPhieuPhat = p.IdPhat,
            MaHopDong = p.IdHd,
            MaQuyDinhPhat = p.IdQdp,
            LyDo = p.LyDo,
            SoTien = p.SoTien,
            NgayPhat = p.NgayPhat,
            TrangThai = p.TrangThai,
            NgayThanhToan = p.NgayThanhToan,
            GhiChu = p.GhiChu
        });
    }

    public async Task<PhieuPhatThongTinDTO?> LayTheoIdAsync(int id)
    {
        var phieuPhat = await _donViCongViec.LayKhoLuuTru<PhieuPhat>().LayTheoIdAsync(id);
        if (phieuPhat == null) return null;

        return new PhieuPhatThongTinDTO
        {
            MaPhieuPhat = phieuPhat.IdPhat,
            MaHopDong = phieuPhat.IdHd,
            MaQuyDinhPhat = phieuPhat.IdQdp,
            LyDo = phieuPhat.LyDo,
            SoTien = phieuPhat.SoTien,
            NgayPhat = phieuPhat.NgayPhat,
            TrangThai = phieuPhat.TrangThai,
            NgayThanhToan = phieuPhat.NgayThanhToan,
            GhiChu = phieuPhat.GhiChu
        };
    }

    public async Task<PhieuPhatThongTinDTO> TaoMoiAsync(PhieuPhatTaoDTO dto)
    {
        var phieuPhatMoi = new PhieuPhat
        {
            IdHd = dto.MaHopDong,
            IdQdp = dto.MaQuyDinhPhat,
            LyDo = dto.LyDo,
            SoTien = dto.SoTien,
            NgayPhat = dto.NgayPhat,
            TrangThai = "Unpaid",
            GhiChu = dto.GhiChu,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<PhieuPhat>().ThemMoiAsync(phieuPhatMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new PhieuPhatThongTinDTO
        {
            MaPhieuPhat = phieuPhatMoi.IdPhat,
            MaHopDong = phieuPhatMoi.IdHd,
            MaQuyDinhPhat = phieuPhatMoi.IdQdp,
            LyDo = phieuPhatMoi.LyDo,
            SoTien = phieuPhatMoi.SoTien,
            NgayPhat = phieuPhatMoi.NgayPhat,
            TrangThai = phieuPhatMoi.TrangThai,
            NgayThanhToan = phieuPhatMoi.NgayThanhToan,
            GhiChu = phieuPhatMoi.GhiChu
        };
    }

    public async Task CapNhatAsync(int id, PhieuPhatCapNhatDTO dto)
    {
        var phieuPhat = await _donViCongViec.LayKhoLuuTru<PhieuPhat>().LayTheoIdAsync(id);
        if (phieuPhat == null)
            throw new KeyNotFoundException($"Không tìm thấy phiếu phạt với ID: {id}");

        if (!string.IsNullOrEmpty(dto.LyDo)) phieuPhat.LyDo = dto.LyDo;
        if (dto.SoTien.HasValue) phieuPhat.SoTien = dto.SoTien.Value;
        phieuPhat.TrangThai = dto.TrangThai;
        phieuPhat.NgayThanhToan = dto.NgayThanhToan;
        phieuPhat.GhiChu = dto.GhiChu;

        _donViCongViec.LayKhoLuuTru<PhieuPhat>().CapNhat(phieuPhat);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var phieuPhat = await _donViCongViec.LayKhoLuuTru<PhieuPhat>().LayTheoIdAsync(id);
        if (phieuPhat == null)
            throw new KeyNotFoundException($"Không tìm thấy phiếu phạt với ID: {id}");

        _donViCongViec.LayKhoLuuTru<PhieuPhat>().Xoa(phieuPhat);
        await _donViCongViec.LuuThayDoiAsync();
    }
}

