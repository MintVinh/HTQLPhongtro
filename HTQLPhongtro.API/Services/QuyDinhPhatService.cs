using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Models.Entities;
using HTQLPhongtro.API.Repositories;

namespace HTQLPhongtro.API.Services;

public class QuyDinhPhatService : IQuyDinhPhatService
{
    private readonly IDonViCongViec _donViCongViec;

    public QuyDinhPhatService(IDonViCongViec donViCongViec)
    {
        _donViCongViec = donViCongViec;
    }

    public async Task<IEnumerable<QuyDinhPhatThongTinDTO>> LayTatCaAsync()
    {
        var danhSach = await _donViCongViec.LayKhoLuuTru<QuyDinhPhat>().LayTatCaAsync();
        return danhSach.Select(q => new QuyDinhPhatThongTinDTO
        {
            MaQuyDinh = q.IdQdp,
            LoaiViPham = q.LoaiViPham,
            MoTa = q.MoTa,
            MucPhat = q.MucPhat,
            DonVi = q.DonVi,
            IsActive = q.IsActive
        });
    }

    public async Task<QuyDinhPhatThongTinDTO?> LayTheoIdAsync(int id)
    {
        var quyDinh = await _donViCongViec.LayKhoLuuTru<QuyDinhPhat>().LayTheoIdAsync(id);
        if (quyDinh == null) return null;

        return new QuyDinhPhatThongTinDTO
        {
            MaQuyDinh = quyDinh.IdQdp,
            LoaiViPham = quyDinh.LoaiViPham,
            MoTa = quyDinh.MoTa,
            MucPhat = quyDinh.MucPhat,
            DonVi = quyDinh.DonVi,
            IsActive = quyDinh.IsActive
        };
    }

    public async Task<QuyDinhPhatThongTinDTO> TaoMoiAsync(QuyDinhPhatTaoDTO dto)
    {
        var quyDinhMoi = new QuyDinhPhat
        {
            LoaiViPham = dto.LoaiViPham,
            MoTa = dto.MoTa,
            MucPhat = dto.MucPhat,
            DonVi = dto.DonVi,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        await _donViCongViec.LayKhoLuuTru<QuyDinhPhat>().ThemMoiAsync(quyDinhMoi);
        await _donViCongViec.LuuThayDoiAsync();

        return new QuyDinhPhatThongTinDTO
        {
            MaQuyDinh = quyDinhMoi.IdQdp,
            LoaiViPham = quyDinhMoi.LoaiViPham,
            MoTa = quyDinhMoi.MoTa,
            MucPhat = quyDinhMoi.MucPhat,
            DonVi = quyDinhMoi.DonVi,
            IsActive = quyDinhMoi.IsActive
        };
    }

    public async Task CapNhatAsync(int id, QuyDinhPhatCapNhatDTO dto)
    {
        var quyDinh = await _donViCongViec.LayKhoLuuTru<QuyDinhPhat>().LayTheoIdAsync(id);
        if (quyDinh == null)
            throw new KeyNotFoundException($"Không tìm thấy quy định phạt với ID: {id}");

        quyDinh.LoaiViPham = dto.LoaiViPham;
        quyDinh.MoTa = dto.MoTa;
        quyDinh.MucPhat = dto.MucPhat;
        quyDinh.DonVi = dto.DonVi;
        quyDinh.IsActive = dto.IsActive;

        _donViCongViec.LayKhoLuuTru<QuyDinhPhat>().CapNhat(quyDinh);
        await _donViCongViec.LuuThayDoiAsync();
    }

    public async Task XoaAsync(int id)
    {
        var quyDinh = await _donViCongViec.LayKhoLuuTru<QuyDinhPhat>().LayTheoIdAsync(id);
        if (quyDinh == null)
            throw new KeyNotFoundException($"Không tìm thấy quy định phạt với ID: {id}");

        _donViCongViec.LayKhoLuuTru<QuyDinhPhat>().Xoa(quyDinh);
        await _donViCongViec.LuuThayDoiAsync();
    }
}

