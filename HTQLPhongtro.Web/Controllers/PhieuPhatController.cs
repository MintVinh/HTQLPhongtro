using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class PhieuPhatController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PhieuPhatController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(int? maHopDong, string? trangThai)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            string url = "api/QuanLyPhieuPhat" + (maHopDong.HasValue || !string.IsNullOrWhiteSpace(trangThai)
                ? $"/tim-kiem?maHopDong={maHopDong}&trangThai={Uri.EscapeDataString(trangThai ?? string.Empty)}"
                : string.Empty);
            var list = await client.GetFromJsonAsync<IEnumerable<PhieuPhatMoHinh>>(url);
            return View(list ?? Array.Empty<PhieuPhatMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<PhieuPhatMoHinh>());
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Tao()
    {
        return View(new PhieuPhatTaoYeuCau());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Tao(PhieuPhatTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/QuanLyPhieuPhat", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Tạo phiếu phạt thất bại");
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
            var item = await client.GetFromJsonAsync<PhieuPhatMoHinh>($"api/QuanLyPhieuPhat/{id}");
            if (item == null) return RedirectToAction(nameof(Index));
            ViewData["MaPhieuPhat"] = id;
            return View(new PhieuPhatCapNhatYeuCau
            {
                LyDo = item.LyDo,
                SoTien = item.SoTien,
                TrangThai = item.TrangThai,
                NgayThanhToan = item.NgayThanhToan,
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
    public async Task<IActionResult> Sua(int id, PhieuPhatCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaPhieuPhat"] = id;
            return View(model);
        }
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PutAsJsonAsync($"api/QuanLyPhieuPhat/{id}", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật phiếu phạt thất bại");
                ViewData["MaPhieuPhat"] = id;
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            ViewData["MaPhieuPhat"] = id;
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
            await client.DeleteAsync($"api/QuanLyPhieuPhat/{id}");
        }
        catch
        {
            TempData["Loi"] = "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.";
        }
        return RedirectToAction(nameof(Index));
    }
}

