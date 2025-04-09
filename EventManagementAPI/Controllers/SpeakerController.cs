using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des intervenants.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService _service;

        /// <summary>
        /// Initialise une nouvelle instance du SpeakerController.
        /// </summary>
        /// <param name="service">Service de gestion des intervenants.</param>
        public SpeakerController(ISpeakerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Récupère la liste de tous les intervenants.
        /// </summary>
        /// <returns>Une liste de SpeakerDTO.</returns>
        /// <response code="200">Retourne la liste des intervenants.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var speakers = await _service.GetAllSpeakersAsync();
            return Ok(speakers);
        }

        /// <summary>
        /// Récupère un intervenant par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de l'intervenant.</param>
        /// <returns>Un SpeakerDTO correspondant.</returns>
        /// <response code="200">Retourne l'intervenant demandé.</response>
        /// <response code="404">Aucun intervenant trouvé pour cet identifiant.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var speaker = await _service.GetSpeakerByIdAsync(id);
            if (speaker == null)
                return NotFound();
            return Ok(speaker);
        }

        /// <summary>
        /// Crée un nouvel intervenant.
        /// </summary>
        /// <param name="dto">Les informations du nouvel intervenant.</param>
        /// <returns>Le SpeakerDTO créé.</returns>
        /// <response code="201">Intervenant créé avec succès.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateSpeakerDTO dto)
        {
            var created = await _service.CreateSpeakerAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Met à jour un intervenant existant.
        /// </summary>
        /// <param name="id">L'identifiant de l'intervenant à mettre à jour.</param>
        /// <param name="dto">Les informations mises à jour de l'intervenant.</param>
        /// <response code="204">Mise à jour effectuée avec succès.</response>
        /// <response code="404">Aucun intervenant correspondant n'a été trouvé.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateSpeakerDTO dto)
        {
            var updated = await _service.UpdateSpeakerAsync(id, dto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Supprime un intervenant.
        /// </summary>
        /// <param name="id">L'identifiant de l'intervenant à supprimer.</param>
        /// <response code="204">Suppression effectuée avec succès.</response>
        /// <response code="404">Aucun intervenant correspondant n'a été trouvé.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteSpeakerAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
