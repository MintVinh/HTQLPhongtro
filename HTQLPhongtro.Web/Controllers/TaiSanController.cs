using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class TaiSanController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TaiSanController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var list = await client.GetFromJsonAsync<IEnumerable<TaiSanMoHinh>>("api/QuanLyTaiSan");
            return View(list ?? Array.Empty<TaiSanMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<TaiSanMoHinh>());
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Tao()
    {
        return View(new TaiSanTaoYeuCau());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Tao(TaiSanTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/QuanLyTaiSan", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Tạo tài sản thất bại");
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
            var item = await client.GetFromJsonAsync<TaiSanMoHinh>($"api/QuanLyTaiSan/{id}");
            if (item == null) return RedirectToAction(nameof(Index));
            ViewData["MaTaiSan"] = id;
            return View(new TaiSanCapNhatYeuCau
            {
                TenTaiSan = item.TenTaiSan,
                MoTa = item.MoTa,
                DonViTinh = item.DonViTinh,
                GiaTri = item.GiaTri
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
    public async Task<IActionResult> Sua(int id, TaiSanCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaTaiSan"] = id;
            return View(model);
        }
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PutAsJsonAsync($"api/QuanLyTaiSan/{id}", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật tài sản thất bại");
                ViewData["MaTaiSan"] = id;
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            ViewData["MaTaiSan"] = id;
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
            await client.DeleteAsync($"api/QuanLyTaiSan/{id}");
        }
        catch
        {
            TempData["Loi"] = "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.";
        }
        return RedirectToAction(nameof(Index));
    }
}

