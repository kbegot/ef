using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;
        public RoomController(IRoomService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllRoomsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _service.GetRoomByIdAsync(id);
            return room == null ? NotFound() : Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomDTO dto)
        {
            var created = await _service.CreateRoomAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateRoomDTO dto)
        {
            var success = await _service.UpdateRoomAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteRoomAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
