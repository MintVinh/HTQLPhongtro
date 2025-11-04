using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class ChiSoDienNuocController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ChiSoDienNuocController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(int? maPhong, int? thang, int? nam)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            string url = "api/QuanLyChiSoDienNuoc" + (maPhong.HasValue || thang.HasValue || nam.HasValue
                ? $"/tim-kiem?maPhong={maPhong}&thang={thang}&nam={nam}"
                : string.Empty);
            var list = await client.GetFromJsonAsync<IEnumerable<ChiSoDienNuocMoHinh>>(url);
            return View(list ?? Array.Empty<ChiSoDienNuocMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<ChiSoDienNuocMoHinh>());
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Tao()
    {
        return View(new ChiSoDienNuocTaoYeuCau());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Tao(ChiSoDienNuocTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/QuanLyChiSoDienNuoc", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Tạo chỉ số điện nước thất bại");
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
            var item = await client.GetFromJsonAsync<ChiSoDienNuocMoHinh>($"api/QuanLyChiSoDienNuoc/{id}");
            if (item == null) return RedirectToAction(nameof(Index));
            ViewData["MaChiSo"] = id;
            return View(new ChiSoDienNuocCapNhatYeuCau
            {
                ChiSoDienMoi = item.ChiSoDienMoi,
                ChiSoNuocMoi = item.ChiSoNuocMoi,
                NgayGhi = item.NgayGhi,
                NguoiGhi = item.NguoiGhi,
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
    public async Task<IActionResult> Sua(int id, ChiSoDienNuocCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaChiSo"] = id;
            return View(model);
        }
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PutAsJsonAsync($"api/QuanLyChiSoDienNuoc/{id}", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật chỉ số điện nước thất bại");
                ViewData["MaChiSo"] = id;
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            ViewData["MaChiSo"] = id;
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
            await client.DeleteAsync($"api/QuanLyChiSoDienNuoc/{id}");
        }
        catch
        {
            TempData["Loi"] = "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.";
        }
        return RedirectToAction(nameof(Index));
    }
}

