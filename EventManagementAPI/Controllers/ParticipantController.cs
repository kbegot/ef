using EventManagementAPI.DTOs;
using EventManagementAPI.Services;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _service;

        public ParticipantController(IParticipantService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var participants = await _service.GetAllParticipantsAsync();
            return Ok(participants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var participant = await _service.GetParticipantByIdAsync(id);
            if (participant == null)
                return NotFound();
            return Ok(participant);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateParticipantDTO dto)
        {
            var created = await _service.CreateParticipantAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateParticipantDTO dto)
        {
            var updated = await _service.UpdateParticipantAsync(id, dto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteParticipantAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
