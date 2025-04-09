using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionSpeakerController : ControllerBase
    {
        private readonly ISessionSpeakerService _service;

        public SessionSpeakerController(ISessionSpeakerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllSessionSpeakersAsync());

        [HttpGet("{sessionId}/{speakerId}")]
        public async Task<IActionResult> GetById(int sessionId, int speakerId)
        {
            var entity = await _service.GetSessionSpeakerAsync(sessionId, speakerId);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSessionSpeakerDTO dto)
        {
            var created = await _service.CreateSessionSpeakerAsync(dto);
            return CreatedAtAction(nameof(GetById), new { sessionId = created.SessionId, speakerId = created.SpeakerId }, created);
        }

        [HttpPut("{sessionId}/{speakerId}")]
        public async Task<IActionResult> Update(int sessionId, int speakerId, [FromBody] CreateSessionSpeakerDTO dto)
        {
            var success = await _service.UpdateSessionSpeakerAsync(sessionId, speakerId, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{sessionId}/{speakerId}")]
        public async Task<IActionResult> Delete(int sessionId, int speakerId)
        {
            var success = await _service.DeleteSessionSpeakerAsync(sessionId, speakerId);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
