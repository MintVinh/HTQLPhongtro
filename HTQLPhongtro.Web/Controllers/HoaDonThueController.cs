using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class HoaDonThueController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HoaDonThueController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(int? maHopDong, int? thang, int? nam, string? trangThai)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            string url = "api/QuanLyHoaDonThue" + (maHopDong.HasValue || thang.HasValue || nam.HasValue || !string.IsNullOrWhiteSpace(trangThai)
                ? $"/tim-kiem?maHopDong={maHopDong}&thang={thang}&nam={nam}&trangThai={Uri.EscapeDataString(trangThai ?? string.Empty)}"
                : string.Empty);
            var list = await client.GetFromJsonAsync<IEnumerable<HoaDonThueMoHinh>>(url);
            return View(list ?? Array.Empty<HoaDonThueMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<HoaDonThueMoHinh>());
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Tao()
    {
        return View(new HoaDonThueTaoYeuCau());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Tao(HoaDonThueTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/QuanLyHoaDonThue", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Tạo hóa đơn thuê thất bại");
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
            var item = await client.GetFromJsonAsync<HoaDonThueMoHinh>($"api/QuanLyHoaDonThue/{id}");
            if (item == null) return RedirectToAction(nameof(Index));
            ViewData["MaHoaDon"] = id;
            return View(new HoaDonThueCapNhatYeuCau
            {
                TienPhong = item.TienPhong,
                TienDien = item.TienDien,
                TienNuoc = item.TienNuoc,
                TienMang = item.TienMang,
                TienRac = item.TienRac,
                TienGuiXe = item.TienGuiXe,
                TienPhat = item.TienPhat,
                GiamGia = item.GiamGia,
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
    public async Task<IActionResult> Sua(int id, HoaDonThueCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaHoaDon"] = id;
            return View(model);
        }
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PutAsJsonAsync($"api/QuanLyHoaDonThue/{id}", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật hóa đơn thuê thất bại");
                ViewData["MaHoaDon"] = id;
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            ViewData["MaHoaDon"] = id;
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
            await client.DeleteAsync($"api/QuanLyHoaDonThue/{id}");
        }
        catch
        {
            TempData["Loi"] = "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.";
        }
        return RedirectToAction(nameof(Index));
    }
}

