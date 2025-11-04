using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class KhachHangController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public KhachHangController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index(string? tuKhoa, string? trangThai)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            string url = "api/QuanLyKhachHang" + (!string.IsNullOrWhiteSpace(tuKhoa) || !string.IsNullOrWhiteSpace(trangThai)
                ? $"/tim-kiem?tuKhoa={Uri.EscapeDataString(tuKhoa ?? string.Empty)}&trangThai={Uri.EscapeDataString(trangThai ?? string.Empty)}"
                : string.Empty);
            var list = await client.GetFromJsonAsync<IEnumerable<KhachHangMoHinh>>(url);
            return View(list ?? Array.Empty<KhachHangMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<KhachHangMoHinh>());
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Tao()
    {
        return View(new KhachHangTaoYeuCau());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Tao(KhachHangTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/QuanLyKhachHang", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Tạo khách hàng thất bại");
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
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
            var item = await client.GetFromJsonAsync<KhachHangMoHinh>($"api/QuanLyKhachHang/{id}");
            if (item == null) return RedirectToAction(nameof(Index));
            ViewData["MaKhach"] = id;
            return View(new KhachHangCapNhatYeuCau
            {
                MaTaiKhoan = item.MaTaiKhoan,
                HoTen = item.HoTen,
                Cccd = item.Cccd,
                Sdt = item.Sdt,
                Email = item.Email,
                DiaChi = item.DiaChi,
                NgaySinh = item.NgaySinh,
                NgheNghiep = item.NgheNghiep,
                TrangThai = item.TrangThai,
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
    public async Task<IActionResult> Sua(int id, KhachHangCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaKhach"] = id;
            return View(model);
        }
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PutAsJsonAsync($"api/QuanLyKhachHang/{id}", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật khách hàng thất bại");
                ViewData["MaKhach"] = id;
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            ViewData["MaKhach"] = id;
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
            await client.DeleteAsync($"api/QuanLyKhachHang/{id}");
        }
        catch
        {
            TempData["Loi"] = "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.";
        }
        return RedirectToAction(nameof(Index));
    }
}

