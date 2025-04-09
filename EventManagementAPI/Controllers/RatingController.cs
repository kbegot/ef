using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des notations des sessions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _service;

        /// <summary>
        /// Initialise une nouvelle instance du contrôleur de notations.
        /// </summary>
        /// <param name="service">Service de gestion des notations.</param>
        public RatingController(IRatingService service)
        {
            _service = service;
        }

        /// <summary>
        /// Récupère toutes les notations.
        /// </summary>
        /// <returns>Liste de RatingDTO.</returns>
        /// <response code="200">Retourne la liste des notations.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllRatingsAsync());

        /// <summary>
        /// Récupère une notation par son identifiant.
        /// </summary>
        /// <param name="id">Identifiant de la notation.</param>
        /// <returns>Un RatingDTO correspondant.</returns>
        /// <response code="200">Retourne la notation.</response>
        /// <response code="404">Si aucune notation n’est trouvée pour cet identifiant.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var rating = await _service.GetRatingByIdAsync(id);
            if (rating == null)
                return NotFound();
            return Ok(rating);
        }

        /// <summary>
        /// Crée une nouvelle notation.
        /// </summary>
        /// <param name="dto">Les informations de la notation à créer.</param>
        /// <returns>Le RatingDTO créé.</returns>
        /// <response code="201">Notation créée avec succès.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateRatingDTO dto)
        {
            var created = await _service.CreateRatingAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Met à jour une notation existante.
        /// </summary>
        /// <param name="id">Identifiant de la notation à mettre à jour.</param>
        /// <param name="dto">Les informations mises à jour de la notation.</param>
        /// <response code="204">Mise à jour effectuée avec succès.</response>
        /// <response code="404">Aucune notation trouvée pour cet identifiant.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateRatingDTO dto)
        {
            var success = await _service.UpdateRatingAsync(id, dto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Supprime une notation.
        /// </summary>
        /// <param name="id">Identifiant de la notation à supprimer.</param>
        /// <response code="204">Suppression effectuée avec succès.</response>
        /// <response code="404">Aucune notation trouvée pour cet identifiant.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteRatingAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
