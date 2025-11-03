namespace HTQLPhongtro.API.Repositories;

public interface IDonViCongViec : IDisposable
{
    IKhoLuuTruChung<T> LayKhoLuuTru<T>() where T : class;
    Task<int> LuuThayDoiAsync();
}
