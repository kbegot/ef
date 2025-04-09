using EventManagementAPI.DTOs;
using EventManagementAPI.DTOs.QueryParameters;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des événements.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _service;

        /// <summary>
        /// Constructeur du contrôleur des événements.
        /// </summary>
        /// <param name="service">Service de gestion des événements.</param>
        public EventController(IEventService service)
        {
            _service = service;
        }

        /// <summary>
        /// Récupère la liste complète des événements.
        /// </summary>
        /// <returns>Une liste d’événements.</returns>
        /// <response code="200">Retourne la liste des événements.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var events = await _service.GetAllEventsAsync();
            return Ok(events);
        }

        /// <summary>
        /// Récupère un événement par son identifiant.
        /// </summary>
        /// <param name="id">L’identifiant de l’événement.</param>
        /// <returns>L’événement correspondant.</returns>
        /// <response code="200">Retourne l’événement.</response>
        /// <response code="404">Si aucun événement n’est trouvé avec cet identifiant.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var ev = await _service.GetEventByIdAsync(id);
            if (ev == null)
                return NotFound();
            return Ok(ev);
        }

        /// <summary>
        /// Crée un nouvel événement.
        /// </summary>
        /// <param name="createEventDto">L’objet contenant les informations de l’événement à créer.</param>
        /// <returns>L’événement créé.</returns>
        /// <response code="201">L’événement a été créé avec succès.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateEventDTO createEventDto)
        {
            var created = await _service.CreateEventAsync(createEventDto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Met à jour un événement existant.
        /// </summary>
        /// <param name="id">L’identifiant de l’événement à mettre à jour.</param>
        /// <param name="updateDto">L’objet contenant les nouvelles informations de l’événement.</param>
        /// <response code="204">La mise à jour a été effectuée avec succès.</response>
        /// <response code="404">Aucun événement trouvé pour cet identifiant.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateEventDTO updateDto)
        {
            var success = await _service.UpdateEventAsync(id, updateDto);
            if (!success)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Supprime un événement.
        /// </summary>
        /// <param name="id">L’identifiant de l’événement à supprimer.</param>
        /// <response code="204">La suppression a été effectuée avec succès.</response>
        /// <response code="404">Aucun événement trouvé pour cet identifiant.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteEventAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Récupère une liste filtrée et paginée d’événements selon les critères spécifiés.
        /// </summary>
        /// <param name="filterParams">Les paramètres de filtrage et de pagination.</param>
        /// <returns>Un résultat paginé contenant la liste des événements correspondants.</returns>
        /// <response code="200">Retourne la liste paginée des événements filtrés.</response>
        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFiltered([FromQuery] EventFilterParameters filterParams)
        {
            var result = await _service.GetFilteredEventsAsync(filterParams);
            return Ok(result);
        }
    }
}
