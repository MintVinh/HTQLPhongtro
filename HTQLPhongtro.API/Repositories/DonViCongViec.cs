using HTQLPhongtro.API.Data;

namespace HTQLPhongtro.API.Repositories;

public class DonViCongViec : IDonViCongViec
{
    private readonly ApplicationDbContext _context;
    private readonly Dictionary<Type, object> _khoLuuTru;

    public DonViCongViec(ApplicationDbContext context)
    {
        _context = context;
        _khoLuuTru = new Dictionary<Type, object>();
    }

    public IKhoLuuTruChung<T> LayKhoLuuTru<T>() where T : class
    {
        var loai = typeof(T);
        if (!_khoLuuTru.ContainsKey(loai))
        {
            _khoLuuTru[loai] = new KhoLuuTruChung<T>(_context);
        }
        return (IKhoLuuTruChung<T>)_khoLuuTru[loai];
    }

    public async Task<int> LuuThayDoiAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
