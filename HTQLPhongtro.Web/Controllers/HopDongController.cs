using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class HopDongController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HopDongController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(string? tuKhoa, string? trangThai)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            string url = "api/QuanLyHopDong" + (!string.IsNullOrWhiteSpace(tuKhoa) || !string.IsNullOrWhiteSpace(trangThai)
                ? $"/tim-kiem?tuKhoa={Uri.EscapeDataString(tuKhoa ?? string.Empty)}&trangThai={Uri.EscapeDataString(trangThai ?? string.Empty)}"
                : string.Empty);
            var list = await client.GetFromJsonAsync<IEnumerable<HopDongMoHinh>>(url);
            return View(list ?? Array.Empty<HopDongMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<HopDongMoHinh>());
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Tao()
    {
        return View(new HopDongTaoYeuCau());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Tao(HopDongTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/QuanLyHopDong", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Tạo hợp đồng thất bại");
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
            var item = await client.GetFromJsonAsync<HopDongMoHinh>($"api/QuanLyHopDong/{id}");
            if (item == null) return RedirectToAction(nameof(Index));
            ViewData["MaHopDong"] = id;
            return View(new HopDongCapNhatYeuCau
            {
                NgayKetThuc = item.NgayKetThuc,
                GiaThue = item.GiaThue,
                ChuKyThanhToan = item.ChuKyThanhToan,
                NgayThanhToan = item.NgayThanhToan,
                TrangThai = item.TrangThai,
                GhiChu = item.GhiChu,
                FileDinhKem = item.FileDinhKem
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
    public async Task<IActionResult> Sua(int id, HopDongCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaHopDong"] = id;
            return View(model);
        }
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PutAsJsonAsync($"api/QuanLyHopDong/{id}", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật hợp đồng thất bại");
                ViewData["MaHopDong"] = id;
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            ViewData["MaHopDong"] = id;
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
            await client.DeleteAsync($"api/QuanLyHopDong/{id}");
        }
        catch
        {
            TempData["Loi"] = "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.";
        }
        return RedirectToAction(nameof(Index));
    }
}

