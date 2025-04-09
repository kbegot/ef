using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des lieux.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;

        /// <summary>
        /// Initialise une nouvelle instance du contrôleur des lieux.
        /// </summary>
        /// <param name="service">Le service de gestion des lieux.</param>
        public LocationController(ILocationService service) => _service = service;

        /// <summary>
        /// Récupère la liste de toutes les locations.
        /// </summary>
        /// <returns>Une liste de LocationDTO.</returns>
        /// <response code="200">Retourne la liste des lieux.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllLocationsAsync());

        /// <summary>
        /// Récupère une location par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la location.</param>
        /// <returns>Un LocationDTO correspondant.</returns>
        /// <response code="200">Retourne la location demandée.</response>
        /// <response code="404">Si aucune location n’est trouvée avec cet identifiant.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var location = await _service.GetLocationByIdAsync(id);
            return location == null ? NotFound() : Ok(location);
        }

        /// <summary>
        /// Crée une nouvelle location.
        /// </summary>
        /// <param name="dto">L’objet contenant les informations de la nouvelle location.</param>
        /// <returns>La location créée.</returns>
        /// <response code="201">Retourne la location créée.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateLocationDTO dto)
        {
            var created = await _service.CreateLocationAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Met à jour une location existante.
        /// </summary>
        /// <param name="id">L'identifiant de la location à mettre à jour.</param>
        /// <param name="dto">L’objet contenant les nouvelles informations de la location.</param>
        /// <response code="204">Si la mise à jour est effectuée avec succès.</response>
        /// <response code="404">Si la location n’est pas trouvée.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateLocationDTO dto)
        {
            var success = await _service.UpdateLocationAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        /// <summary>
        /// Supprime une location.
        /// </summary>
        /// <param name="id">L'identifiant de la location à supprimer.</param>
        /// <response code="204">Si la suppression est effectuée avec succès.</response>
        /// <response code="404">Si la location n’est pas trouvée.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteLocationAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
