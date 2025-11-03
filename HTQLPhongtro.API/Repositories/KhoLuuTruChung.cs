using HTQLPhongtro.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HTQLPhongtro.API.Repositories;

public class KhoLuuTruChung<T> : IKhoLuuTruChung<T> where T : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public KhoLuuTruChung(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> LayTheoIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> LayTatCaAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> TimKiemAsync(Expression<Func<T, bool>> bieuThuc)
    {
        return await _dbSet.Where(bieuThuc).ToListAsync();
    }

    public async Task ThemMoiAsync(T doiTuong)
    {
        await _dbSet.AddAsync(doiTuong);
    }

    public async Task ThemNhieuAsync(IEnumerable<T> danhSach)
    {
        await _dbSet.AddRangeAsync(danhSach);
    }

    public void CapNhat(T doiTuong)
    {
        _dbSet.Update(doiTuong);
    }

    public void Xoa(T doiTuong)
    {
        _dbSet.Remove(doiTuong);
    }

    public void XoaNhieu(IEnumerable<T> danhSach)
    {
        _dbSet.RemoveRange(danhSach);
    }
}
