using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.Web.Controllers;

public class TaiKhoanController : Controller
{
    [HttpGet]
    public IActionResult DangNhap(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DangNhap(string username, string password, string? returnUrl = null)
    {
        if (string.Equals(username, "admin", StringComparison.OrdinalIgnoreCase) && password == "1")
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "admin"),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("Cookies", principal);
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError(string.Empty, "Sai tên đăng nhập hoặc mật khẩu.");
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> DangXuat()
    {
        await HttpContext.SignOutAsync("Cookies");
        return RedirectToAction("DangNhap");
    }
}


