using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des sessions d'événements.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;

        /// <summary>
        /// Initialise une nouvelle instance de SessionController.
        /// </summary>
        /// <param name="service">Le service de gestion des sessions.</param>
        public SessionController(ISessionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Récupère toutes les sessions.
        /// </summary>
        /// <returns>Une liste de SessionDTO.</returns>
        /// <response code="200">Retourne la liste des sessions.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var sessions = await _service.GetAllSessionsAsync();
            return Ok(sessions);
        }

        /// <summary>
        /// Récupère une session par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la session.</param>
        /// <returns>Le SessionDTO correspondant.</returns>
        /// <response code="200">Retourne la session.</response>
        /// <response code="404">Aucune session trouvée avec cet identifiant.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var session = await _service.GetSessionByIdAsync(id);
            if (session == null)
                return NotFound();
            return Ok(session);
        }

        /// <summary>
        /// Crée une nouvelle session.
        /// </summary>
        /// <param name="dto">Les informations de la session à créer.</param>
        /// <returns>Le SessionDTO créé.</returns>
        /// <response code="201">Retourne la session créée.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateSessionDTO dto)
        {
            var created = await _service.CreateSessionAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Met à jour une session existante.
        /// </summary>
        /// <param name="id">L'identifiant de la session à mettre à jour.</param>
        /// <param name="dto">Les informations mises à jour de la session.</param>
        /// <response code="204">La mise à jour a été effectuée avec succès.</response>
        /// <response code="404">Aucune session trouvée pour cet identifiant.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateSessionDTO dto)
        {
            var updated = await _service.UpdateSessionAsync(id, dto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Supprime une session.
        /// </summary>
        /// <param name="id">L'identifiant de la session à supprimer.</param>
        /// <response code="204">La suppression a été effectuée avec succès.</response>
        /// <response code="404">Aucune session trouvée avec cet identifiant.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteSessionAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
