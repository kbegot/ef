using EventManagementAPI.DTOs;
using EventManagementAPI.DTOs.QueryParameters;
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
                return NotFound();
            return Ok(ev);
        }

        // POST : api/Event
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDTO createEventDto)
        {
            var created = await _service.CreateEventAsync(createEventDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT : api/Event/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateEventDTO updateDto)
        {
            var success = await _service.UpdateEventAsync(id, updateDto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        // DELETE : api/Event/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteEventAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        // GET : api/Event/filter
        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered([FromQuery] EventFilterParameters filterParams)
        {
            var result = await _service.GetFilteredEventsAsync(filterParams);
            return Ok(result);
        }
    }
}
