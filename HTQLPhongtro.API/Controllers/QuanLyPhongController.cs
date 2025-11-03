// HTQLPhongtro.API/Controllers/QuanLyPhongController.cs
using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuanLyPhongController : ControllerBase
{
    private readonly IQuanLyPhongService _quanLyPhongService;

    public QuanLyPhongController(IQuanLyPhongService quanLyPhongService)
    {
        _quanLyPhongService = quanLyPhongService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ThongTinPhongDTO>>> LayDanhSachPhong()
    {
        var danhSachPhong = await _quanLyPhongService.LayTatCaPhongAsync();
        return Ok(danhSachPhong);
    }

    [HttpGet("tim-kiem")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ThongTinPhongDTO>>> TimKiem([FromQuery] string? tuKhoa, [FromQuery] string? trangThai)
    {
        var ketQua = await _quanLyPhongService.TimKiemPhongAsync(tuKhoa, trangThai);
        return Ok(ketQua);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ThongTinPhongDTO>> LayThongTinPhong(int id)
    {
        var phong = await _quanLyPhongService.LayPhongTheoIdAsync(id);
        if (phong == null)
            return NotFound("Không tìm thấy phòng");

        return Ok(phong);
    }

    [HttpPost]
    public async Task<ActionResult<ThongTinPhongDTO>> TaoPhongMoi(TaoPhongMoiDTO taoPhongDto)
    {
        var phongMoi = await _quanLyPhongService.TaoPhongMoiAsync(taoPhongDto);
        return CreatedAtAction(nameof(LayThongTinPhong), new { id = phongMoi.MaPhong }, phongMoi);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> CapNhatPhong(int id, CapNhatPhongDTO capNhatPhongDto)
    {
        try
        {
            await _quanLyPhongService.CapNhatPhongAsync(id, capNhatPhongDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Không tìm thấy phòng");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> XoaPhong(int id)
    {
        try
        {
            await _quanLyPhongService.XoaPhongAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound("Không tìm thấy phòng");
        }
    }
}
