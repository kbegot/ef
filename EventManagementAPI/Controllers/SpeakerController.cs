using EventManagementAPI.DTOs;
using EventManagementAPI.Services;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _service;

        public SpeakerController(ISpeakerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var speakers = await _service.GetAllSpeakersAsync();
            return Ok(speakers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var speaker = await _service.GetSpeakerByIdAsync(id);
            if (speaker == null)
                return NotFound();
            return Ok(speaker);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSpeakerDTO dto)
        {
            var created = await _service.CreateSpeakerAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateSpeakerDTO dto)
        {
            var updated = await _service.UpdateSpeakerAsync(id, dto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteSpeakerAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
