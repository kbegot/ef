using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des inscriptions et désinscriptions aux événements.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _service;

        /// <summary>
        /// Initialise une nouvelle instance du RegistrationController.
        /// </summary>
        /// <param name="service">Service de gestion des inscriptions aux événements.</param>
        public RegistrationController(IRegistrationService service)
        {
            _service = service;
        }

        /// <summary>
        /// Inscrit un participant à un événement.
        /// </summary>
        /// <param name="dto">Les informations d'inscription (EventId et ParticipantId).</param>
        /// <returns>Un message indiquant si l'inscription a réussi.</returns>
        /// <response code="200">Retourne un message confirmant l'inscription réussie.</response>
        /// <response code="400">Retourne une erreur si l'inscription existe déjà ou en cas d'erreur.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO dto)
        {
            var success = await _service.RegisterAsync(dto);
            if (!success)
                return BadRequest("Inscription déjà existante ou erreur.");
            return Ok("Inscription réussie.");
        }

        /// <summary>
        /// Désinscrit un participant d'un événement.
        /// </summary>
        /// <param name="eventId">L'identifiant de l'événement.</param>
        /// <param name="participantId">L'identifiant du participant.</param>
        /// <returns>Un message indiquant si la désinscription a réussi.</returns>
        /// <response code="200">Retourne un message confirmant la désinscription réussie.</response>
        /// <response code="404">Retourne une erreur si l'inscription n'est pas trouvée.</response>
        [HttpDelete("{eventId}/{participantId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Unregister(int eventId, int participantId)
        {
            var success = await _service.UnregisterAsync(eventId, participantId);
            if (!success)
                return NotFound("Inscription non trouvée.");
            return Ok("Désinscription réussie.");
        }
    }
}
