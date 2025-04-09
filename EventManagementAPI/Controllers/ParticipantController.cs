using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des participants.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _service;

        /// <summary>
        /// Initialise une nouvelle instance du ParticipantController.
        /// </summary>
        /// <param name="service">Le service de gestion des participants.</param>
        public ParticipantController(IParticipantService service)
        {
            _service = service;
        }

        /// <summary>
        /// Récupère la liste de tous les participants.
        /// </summary>
        /// <returns>Une liste de ParticipantDTO.</returns>
        /// <response code="200">Retourne la liste des participants.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var participants = await _service.GetAllParticipantsAsync();
            return Ok(participants);
        }

        /// <summary>
        /// Récupère un participant par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du participant.</param>
        /// <returns>Le ParticipantDTO correspondant.</returns>
        /// <response code="200">Retourne le participant.</response>
        /// <response code="404">Aucun participant n'a été trouvé.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var participant = await _service.GetParticipantByIdAsync(id);
            if (participant == null)
                return NotFound();
            return Ok(participant);
        }

        /// <summary>
        /// Crée un nouveau participant.
        /// </summary>
        /// <param name="dto">Les informations du nouveau participant.</param>
        /// <returns>Le ParticipantDTO créé.</returns>
        /// <response code="201">Participant créé avec succès.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateParticipantDTO dto)
        {
            var created = await _service.CreateParticipantAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Met à jour un participant existant.
        /// </summary>
        /// <param name="id">L'identifiant du participant à mettre à jour.</param>
        /// <param name="dto">Les nouvelles informations du participant.</param>
        /// <response code="204">Mise à jour effectuée avec succès.</response>
        /// <response code="404">Aucun participant correspondant n'a été trouvé.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateParticipantDTO dto)
        {
            var updated = await _service.UpdateParticipantAsync(id, dto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Supprime un participant par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant du participant à supprimer.</param>
        /// <response code="204">Suppression effectuée avec succès.</response>
        /// <response code="404">Aucun participant correspondant n'a été trouvé.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteParticipantAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
