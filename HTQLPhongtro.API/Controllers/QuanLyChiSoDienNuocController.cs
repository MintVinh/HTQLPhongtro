using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuanLyChiSoDienNuocController : ControllerBase
{
    private readonly IChiSoDienNuocService _service;

    public QuanLyChiSoDienNuocController(IChiSoDienNuocService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ChiSoDienNuocThongTinDTO>>> LayDanhSach()
    {
        var result = await _service.LayTatCaAsync();
        return Ok(result);
    }

    [HttpGet("tim-kiem")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ChiSoDienNuocThongTinDTO>>> TimKiem([FromQuery] int? maPhong, [FromQuery] int? thang, [FromQuery] int? nam)
    {
        var result = await _service.TimKiemAsync(maPhong, thang, nam);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ChiSoDienNuocThongTinDTO>> LayTheoId(int id)
    {
        var result = await _service.LayTheoIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ChiSoDienNuocThongTinDTO>> TaoMoi(ChiSoDienNuocTaoDTO dto)
    {
        var created = await _service.TaoMoiAsync(dto);
        return CreatedAtAction(nameof(LayTheoId), new { id = created.MaChiSo }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> CapNhat(int id, ChiSoDienNuocCapNhatDTO dto)
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

