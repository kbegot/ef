using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des associations entre sessions et intervenants (SessionSpeakers).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SessionSpeakerController : ControllerBase
    {
        private readonly ISessionSpeakerService _service;

        /// <summary>
        /// Initialise une nouvelle instance du SessionSpeakerController.
        /// </summary>
        /// <param name="service">Le service de gestion des associations session-speaker.</param>
        public SessionSpeakerController(ISessionSpeakerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Récupère la liste de toutes les associations session-speaker.
        /// </summary>
        /// <returns>Une liste de SessionSpeakerDTO.</returns>
        /// <response code="200">Retourne la liste des associations.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllSessionSpeakersAsync());

        /// <summary>
        /// Récupère une association session-speaker spécifique.
        /// </summary>
        /// <param name="sessionId">Identifiant de la session.</param>
        /// <param name="speakerId">Identifiant de l'intervenant.</param>
        /// <returns>Un SessionSpeakerDTO correspondant.</returns>
        /// <response code="200">Retourne l'association demandée.</response>
        /// <response code="404">Aucune association trouvée pour ces identifiants.</response>
        [HttpGet("{sessionId}/{speakerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int sessionId, int speakerId)
        {
            var entity = await _service.GetSessionSpeakerAsync(sessionId, speakerId);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }

        /// <summary>
        /// Crée une nouvelle association entre une session et un intervenant.
        /// </summary>
        /// <param name="dto">Les informations de l'association à créer.</param>
        /// <returns>Le SessionSpeakerDTO créé.</returns>
        /// <response code="201">Association créée avec succès.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateSessionSpeakerDTO dto)
        {
            var created = await _service.CreateSessionSpeakerAsync(dto);
            return CreatedAtAction(nameof(GetById), new { sessionId = created.SessionId, speakerId = created.SpeakerId }, created);
        }

        /// <summary>
        /// Met à jour une association session-speaker existante.
        /// </summary>
        /// <param name="sessionId">Identifiant de la session.</param>
        /// <param name="speakerId">Identifiant de l'intervenant.</param>
        /// <param name="dto">Les informations mises à jour pour l'association.</param>
        /// <response code="204">Mise à jour effectuée avec succès.</response>
        /// <response code="404">Aucune association trouvée pour ces identifiants.</response>
        [HttpPut("{sessionId}/{speakerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int sessionId, int speakerId, [FromBody] CreateSessionSpeakerDTO dto)
        {
            var success = await _service.UpdateSessionSpeakerAsync(sessionId, speakerId, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Supprime une association entre une session et un intervenant.
        /// </summary>
        /// <param name="sessionId">Identifiant de la session.</param>
        /// <param name="speakerId">Identifiant de l'intervenant.</param>
        /// <response code="204">Suppression effectuée avec succès.</response>
        /// <response code="404">Aucune association trouvée pour ces identifiants.</response>
        [HttpDelete("{sessionId}/{speakerId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int sessionId, int speakerId)
        {
            var success = await _service.DeleteSessionSpeakerAsync(sessionId, speakerId);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
