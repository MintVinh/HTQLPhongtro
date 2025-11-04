using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class ThongBaoController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ThongBaoController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var list = await client.GetFromJsonAsync<IEnumerable<ThongBaoMoHinh>>("api/QuanLyThongBao");
            return View(list ?? Array.Empty<ThongBaoMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<ThongBaoMoHinh>());
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Tao()
    {
        return View(new ThongBaoTaoYeuCau());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Tao(ThongBaoTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/QuanLyThongBao", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Tạo thông báo thất bại");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            return View(model);
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Sua(int id)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var item = await client.GetFromJsonAsync<ThongBaoMoHinh>($"api/QuanLyThongBao/{id}");
            if (item == null) return RedirectToAction(nameof(Index));
            ViewData["MaThongBao"] = id;
            return View(new ThongBaoCapNhatYeuCau
            {
                LoaiThongBao = item.LoaiThongBao,
                TieuDe = item.TieuDe,
                NoiDung = item.NoiDung,
                MucDo = item.MucDo,
                NgayHetHan = item.NgayHetHan,
                IsActive = item.IsActive
            });
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Sua(int id, ThongBaoCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaThongBao"] = id;
            return View(model);
        }
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PutAsJsonAsync($"api/QuanLyThongBao/{id}", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật thông báo thất bại");
                ViewData["MaThongBao"] = id;
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            ViewData["MaThongBao"] = id;
            return View(model);
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Xoa(int id)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            await client.DeleteAsync($"api/QuanLyThongBao/{id}");
        }
        catch
        {
            TempData["Loi"] = "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.";
        }
        return RedirectToAction(nameof(Index));
    }
}

