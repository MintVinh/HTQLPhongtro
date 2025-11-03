using System.Linq.Expressions;

namespace HTQLPhongtro.API.Repositories;

public interface IKhoLuuTruChung<T> where T : class
{
    Task<T?> LayTheoIdAsync(int id);
    Task<IEnumerable<T>> LayTatCaAsync();
    Task<IEnumerable<T>> TimKiemAsync(Expression<Func<T, bool>> bieuThuc);
    Task ThemMoiAsync(T doiTuong);
    Task ThemNhieuAsync(IEnumerable<T> danhSach);
    void CapNhat(T doiTuong);
    void Xoa(T doiTuong);
    void XoaNhieu(IEnumerable<T> danhSach);
}
