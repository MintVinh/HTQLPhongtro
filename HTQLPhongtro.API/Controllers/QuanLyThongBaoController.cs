using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuanLyThongBaoController : ControllerBase
{
    private readonly IThongBaoService _service;

    public QuanLyThongBaoController(IThongBaoService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<ThongBaoThongTinDTO>>> LayDanhSach()
    {
        var result = await _service.LayTatCaAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<ThongBaoThongTinDTO>> LayTheoId(int id)
    {
        var result = await _service.LayTheoIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ThongBaoThongTinDTO>> TaoMoi(ThongBaoTaoDTO dto)
    {
        var created = await _service.TaoMoiAsync(dto);
        return CreatedAtAction(nameof(LayTheoId), new { id = created.MaThongBao }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> CapNhat(int id, ThongBaoCapNhatDTO dto)
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

