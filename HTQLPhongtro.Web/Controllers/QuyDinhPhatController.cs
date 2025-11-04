using System.Net.Http.Json;
using HTQLPhongtro.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class QuyDinhPhatController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public QuyDinhPhatController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var list = await client.GetFromJsonAsync<IEnumerable<QuyDinhPhatMoHinh>>("api/QuanLyQuyDinhPhat");
            return View(list ?? Array.Empty<QuyDinhPhatMoHinh>());
        }
        catch
        {
            TempData["Loi"] = "Không thể tải dữ liệu. Vui lòng đảm bảo API đang chạy.";
            return View(Array.Empty<QuyDinhPhatMoHinh>());
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Tao()
    {
        return View(new QuyDinhPhatTaoYeuCau());
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Tao(QuyDinhPhatTaoYeuCau model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PostAsJsonAsync("api/QuanLyQuyDinhPhat", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Tạo quy định phạt thất bại");
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
            var item = await client.GetFromJsonAsync<QuyDinhPhatMoHinh>($"api/QuanLyQuyDinhPhat/{id}");
            if (item == null) return RedirectToAction(nameof(Index));
            ViewData["MaQuyDinh"] = id;
            return View(new QuyDinhPhatCapNhatYeuCau
            {
                LoaiViPham = item.LoaiViPham,
                MoTa = item.MoTa,
                MucPhat = item.MucPhat,
                DonVi = item.DonVi,
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
    public async Task<IActionResult> Sua(int id, QuyDinhPhatCapNhatYeuCau model)
    {
        if (!ModelState.IsValid)
        {
            ViewData["MaQuyDinh"] = id;
            return View(model);
        }
        try
        {
            var client = _httpClientFactory.CreateClient("ApiClient");
            var resp = await client.PutAsJsonAsync($"api/QuanLyQuyDinhPhat/{id}", model);
            if (!resp.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Cập nhật quy định phạt thất bại");
                ViewData["MaQuyDinh"] = id;
                return View(model);
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.");
            ViewData["MaQuyDinh"] = id;
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
            await client.DeleteAsync($"api/QuanLyQuyDinhPhat/{id}");
        }
        catch
        {
            TempData["Loi"] = "Không thể kết nối đến API. Vui lòng đảm bảo API đang chạy.";
        }
        return RedirectToAction(nameof(Index));
    }
}

