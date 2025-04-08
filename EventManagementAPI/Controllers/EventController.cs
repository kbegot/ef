using EventManagementAPI.DTOs;
using EventManagementAPI.Services;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _service;

        public EventController(IEventService service)
        {
            _service = service;
        }

        // GET : api/Event
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _service.GetAllEventsAsync();
            return Ok(events);
        }

        // GET : api/Event/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ev = await _service.GetEventByIdAsync(id);
            if (ev == null)
            {
                return NotFound();
            }
            return Ok(ev);
        }

        // POST : api/Event
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDTO createEventDto)
        {
            var createdEvent = await _service.CreateEventAsync(createEventDto);
            return CreatedAtAction(nameof(GetById), new { id = createdEvent.Id }, createdEvent);
        }

        // PUT : api/Event/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateEventDTO updateEventDto)
        {
            var result = await _service.UpdateEventAsync(id, updateEventDto);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE : api/Event/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteEventAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
