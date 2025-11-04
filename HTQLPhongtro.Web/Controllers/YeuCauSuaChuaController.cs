using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class YeuCauSuaChuaController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public YeuCauSuaChuaController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(string? tuKhoa, string? trangThai)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            string url = "api/QuanLyYeuCauSuaChua" + (!string.IsNullOrWhiteSpace(tuKhoa) || !string.IsNullOrWhiteSpace(trangThai)
                ? $"/tim-kiem?tuKhoa={Uri.EscapeDataString(tuKhoa ?? string.Empty)}&trangThai={Uri.EscapeDataString(trangThai ?? string.Empty)}"
                : string.Empty);
            var list = await client.GetFromJsonAsync<IEnumerable<YeuCauSuaChuaMoHinh>>(url);
            return View(list ?? Array.Empty<YeuCauSuaChuaMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<YeuCauSuaChuaMoHinh>());
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Tao()
    {
        return View(new YeuCauSuaChuaTaoYeuCau());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Tao(YeuCauSuaChuaTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/QuanLyYeuCauSuaChua", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Tạo yêu cầu sửa chữa thất bại");
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
            var item = await client.GetFromJsonAsync<YeuCauSuaChuaMoHinh>($"api/QuanLyYeuCauSuaChua/{id}");
            if (item == null) return RedirectToAction(nameof(Index));
            ViewData["MaYeuCau"] = id;
            return View(new YeuCauSuaChuaCapNhatYeuCau
            {
                TieuDe = item.TieuDe,
                MoTa = item.MoTa,
                MucDo = item.MucDo,
                TrangThai = item.TrangThai,
                NgayXuLy = item.NgayXuLy,
                NgayHoanThanh = item.NgayHoanThanh,
                NguoiXuLy = item.NguoiXuLy,
                ChiPhi = item.ChiPhi,
                GhiChu = item.GhiChu
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
    public async Task<IActionResult> Sua(int id, YeuCauSuaChuaCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaYeuCau"] = id;
            return View(model);
        }
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PutAsJsonAsync($"api/QuanLyYeuCauSuaChua/{id}", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật yêu cầu sửa chữa thất bại");
                ViewData["MaYeuCau"] = id;
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            ViewData["MaYeuCau"] = id;
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
            await client.DeleteAsync($"api/QuanLyYeuCauSuaChua/{id}");
        }
        catch
        {
            TempData["Loi"] = "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.";
        }
        return RedirectToAction(nameof(Index));
    }
}

