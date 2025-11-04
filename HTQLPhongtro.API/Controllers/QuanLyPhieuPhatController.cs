using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuanLyPhieuPhatController : ControllerBase
{
    private readonly IPhieuPhatService _service;

    public QuanLyPhieuPhatController(IPhieuPhatService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<PhieuPhatThongTinDTO>>> LayDanhSach()
    {
        var result = await _service.LayTatCaAsync();
        return Ok(result);
    }

    [HttpGet("tim-kiem")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<PhieuPhatThongTinDTO>>> TimKiem([FromQuery] int? maHopDong, [FromQuery] string? trangThai)
    {
        var result = await _service.TimKiemAsync(maHopDong, trangThai);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<PhieuPhatThongTinDTO>> LayTheoId(int id)
    {
        var result = await _service.LayTheoIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<PhieuPhatThongTinDTO>> TaoMoi(PhieuPhatTaoDTO dto)
    {
        var created = await _service.TaoMoiAsync(dto);
        return CreatedAtAction(nameof(LayTheoId), new { id = created.MaPhieuPhat }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> CapNhat(int id, PhieuPhatCapNhatDTO dto)
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

