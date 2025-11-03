using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class LoaiPhongController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LoaiPhongController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(string? tuKhoa, bool? isActive)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            string url = "api/QuanLyLoaiPhong" + (!string.IsNullOrWhiteSpace(tuKhoa) || isActive.HasValue
                ? $"/tim-kiem?tuKhoa={Uri.EscapeDataString(tuKhoa ?? string.Empty)}&isActive={(isActive.HasValue ? isActive.Value.ToString().ToLower() : string.Empty)}"
                : string.Empty);
            var list = await client.GetFromJsonAsync<IEnumerable<LoaiPhongMoHinh>>(url);
            return View(list ?? Array.Empty<LoaiPhongMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<LoaiPhongMoHinh>());
        }
    }

    [HttpGet]
    public IActionResult Tao()
    {
        return View(new LoaiPhongTaoYeuCau());
    }

    [HttpPost]
    public async Task<IActionResult> Tao(LoaiPhongTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        var client = _httpClientFactory.CreateClient("ApiClient");
        var resp = await client.PostAsJsonAsync("api/QuanLyLoaiPhong", model);
        if (!resp.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Tạo loại phòng thất bại");
            return View(model);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Sua(int id)
    {
        var client = _httpClientFactory.CreateClient("ApiClient");
        var item = await client.GetFromJsonAsync<LoaiPhongMoHinh>($"api/QuanLyLoaiPhong/{id}");
        if (item == null) return RedirectToAction(nameof(Index));
        ViewData["MaLoai"] = id;
        return View(new LoaiPhongCapNhatYeuCau
        {
            TenLoai = item.TenLoai,
            MoTa = item.MoTa,
            GiaThueGocMin = item.GiaThueGocMin,
            GiaThueGocMax = item.GiaThueGocMax,
            IsActive = item.IsActive
        });
    }

    [HttpPost]
    public async Task<IActionResult> Sua(int id, LoaiPhongCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaLoai"] = id;
            return View(model);
        }
        var client = _httpClientFactory.CreateClient("ApiClient");
        var resp = await client.PutAsJsonAsync($"api/QuanLyLoaiPhong/{id}", model);
        if (!resp.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Cập nhật loại phòng thất bại");
            ViewData["MaLoai"] = id;
            return View(model);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Xoa(int id)
    {
        var client = _httpClientFactory.CreateClient("ApiClient");
        await client.DeleteAsync($"api/QuanLyLoaiPhong/{id}");
        return RedirectToAction(nameof(Index));
    }
}


