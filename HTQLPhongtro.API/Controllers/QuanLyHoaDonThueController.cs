using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuanLyHoaDonThueController : ControllerBase
{
    private readonly IHoaDonThueService _service;

    public QuanLyHoaDonThueController(IHoaDonThueService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<HoaDonThueThongTinDTO>>> LayDanhSach()
    {
        var result = await _service.LayTatCaAsync();
        return Ok(result);
    }

    [HttpGet("tim-kiem")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<HoaDonThueThongTinDTO>>> TimKiem([FromQuery] int? maHopDong, [FromQuery] int? thang, [FromQuery] int? nam, [FromQuery] string? trangThai)
    {
        var result = await _service.TimKiemAsync(maHopDong, thang, nam, trangThai);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<HoaDonThueThongTinDTO>> LayTheoId(int id)
    {
        var result = await _service.LayTheoIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<HoaDonThueThongTinDTO>> TaoMoi(HoaDonThueTaoDTO dto)
    {
        var created = await _service.TaoMoiAsync(dto);
        return CreatedAtAction(nameof(LayTheoId), new { id = created.MaHoaDon }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> CapNhat(int id, HoaDonThueCapNhatDTO dto)
    {
        try
        {
            await _service.CapNhatAsync(id, dto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Xoa(int id)
    {
        try
        {
            await _service.XoaAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}

