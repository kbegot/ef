using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;
        public RegistrationController(IRegistrationService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO dto)
        {
            var success = await _service.RegisterAsync(dto);
            if (!success)
                return BadRequest("Inscription déjà existante ou erreur.");
            return Ok("Inscription réussie.");
        }

        [HttpDelete("{eventId}/{participantId}")]
        public async Task<IActionResult> Unregister(int eventId, int participantId)
        {
            var success = await _service.UnregisterAsync(eventId, participantId);
            if (!success)
                return NotFound("Inscription non trouvée.");
            return Ok("Désinscription réussie.");
        }
    }
}
