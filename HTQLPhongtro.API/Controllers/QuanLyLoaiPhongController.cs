using HTQLPhongtro.API.DTOs;
using HTQLPhongtro.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HTQLPhongtro.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class QuanLyLoaiPhongController : ControllerBase
{
    private readonly ILoaiPhongService _service;

    public QuanLyLoaiPhongController(ILoaiPhongService service)
    {
        _service = service;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<LoaiPhongThongTinDTO>>> LayDanhSach()
    {
        var result = await _service.LayTatCaAsync();
        return Ok(result);
    }

    [HttpGet("tim-kiem")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<LoaiPhongThongTinDTO>>> TimKiem([FromQuery] string? tuKhoa, [FromQuery] bool? isActive)
    {
        var result = await _service.TimKiemAsync(tuKhoa, isActive);
        return Ok(result);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<LoaiPhongThongTinDTO>> LayTheoId(int id)
    {
        var result = await _service.LayTheoIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<LoaiPhongThongTinDTO>> TaoMoi(LoaiPhongTaoDTO dto)
    {
        var created = await _service.TaoMoiAsync(dto);
        return CreatedAtAction(nameof(LayTheoId), new { id = created.MaLoai }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> CapNhat(int id, LoaiPhongCapNhatDTO dto)
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


