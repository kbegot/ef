using EventManagementAPI.DTOs;
using EventManagementAPI.Services;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;

        public SessionController(ISessionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await _service.GetAllSessionsAsync();
            return Ok(sessions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var session = await _service.GetSessionByIdAsync(id);
            if (session == null)
                return NotFound();
            return Ok(session);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSessionDTO dto)
        {
            var created = await _service.CreateSessionAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateSessionDTO dto)
        {
            var updated = await _service.UpdateSessionAsync(id, dto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteSessionAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
