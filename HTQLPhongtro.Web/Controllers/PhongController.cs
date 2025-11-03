using System.Net.Http;
using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class PhongController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PhongController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(string? tuKhoa, string? trangThai)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            string url = "api/QuanLyPhong" + (!string.IsNullOrWhiteSpace(tuKhoa) || !string.IsNullOrWhiteSpace(trangThai)
                ? $"/tim-kiem?tuKhoa={Uri.EscapeDataString(tuKhoa ?? string.Empty)}&trangThai={Uri.EscapeDataString(trangThai ?? string.Empty)}"
                : string.Empty);
            var rooms = await client.GetFromJsonAsync<IEnumerable<PhongMoHinh>>(url);
            return View(rooms ?? Array.Empty<PhongMoHinh>());
        }
        catch (Exception ex)
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<PhongMoHinh>());
        }
    }

    [HttpGet]
    public IActionResult Tao()
    {
        return View(new PhongTaoYeuCau());
    }

    [HttpPost]
    public async Task<IActionResult> Tao(PhongTaoYeuCau yeuCau)
    {
        if (!ModelState.IsValid) return View(yeuCau);
        var client = _httpClientFactory.CreateClient("ApiClient");
        var resp = await client.PostAsJsonAsync("api/QuanLyPhong", yeuCau);
        if (!resp.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Tạo phòng thất bại");
            return View(yeuCau);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Sua(int id)
    {
        var client = _httpClientFactory.CreateClient("ApiClient");
        var phong = await client.GetFromJsonAsync<PhongMoHinh>($"api/QuanLyPhong/{id}");
        if (phong == null) return RedirectToAction(nameof(Index));
        var model = new PhongCapNhatYeuCau
        {
            TenPhong = phong.TenPhong,
            GiaThue = phong.GiaThue,
            SoNguoiToiDa = phong.SoNguoiToiDa,
            MoTa = phong.MoTa
        };
        ViewData["MaPhong"] = id;
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Sua(int id, PhongCapNhatYeuCau yeuCau)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaPhong"] = id;
            return View(yeuCau);
        }
        var client = _httpClientFactory.CreateClient("ApiClient");
        var resp = await client.PutAsJsonAsync($"api/QuanLyPhong/{id}", yeuCau);
        if (!resp.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Cập nhật phòng thất bại");
            ViewData["MaPhong"] = id;
            return View(yeuCau);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Xoa(int id)
    {
        var client = _httpClientFactory.CreateClient("ApiClient");
        var resp = await client.DeleteAsync($"api/QuanLyPhong/{id}");
        return RedirectToAction(nameof(Index));
    }
}


