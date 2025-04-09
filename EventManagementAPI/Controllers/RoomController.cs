using EventManagementAPI.DTOs;
using EventManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des salles (Rooms).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        /// <summary>
        /// Initialise une nouvelle instance du RoomController.
        /// </summary>
        /// <param name="service">Le service de gestion des salles.</param>
        public RoomController(IRoomService service) => _service = service;

        /// <summary>
        /// Récupère la liste de toutes les salles.
        /// </summary>
        /// <returns>Une liste de RoomDTO.</returns>
        /// <response code="200">Retourne la liste des salles.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllRoomsAsync());

        /// <summary>
        /// Récupère une salle par son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la salle.</param>
        /// <returns>Un RoomDTO correspondant.</returns>
        /// <response code="200">Retourne la salle demandée.</response>
        /// <response code="404">Si aucune salle n’est trouvée pour cet identifiant.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _service.GetRoomByIdAsync(id);
            return room == null ? NotFound() : Ok(room);
        }

        /// <summary>
        /// Crée une nouvelle salle.
        /// </summary>
        /// <param name="dto">Les informations de la salle à créer.</param>
        /// <returns>Le RoomDTO créé.</returns>
        /// <response code="201">Salle créée avec succès.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateRoomDTO dto)
        {
            var created = await _service.CreateRoomAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Met à jour une salle existante.
        /// </summary>
        /// <param name="id">L'identifiant de la salle à mettre à jour.</param>
        /// <param name="dto">Les informations mises à jour de la salle.</param>
        /// <response code="204">Mise à jour effectuée avec succès.</response>
        /// <response code="404">Si aucune salle correspondante n’est trouvée.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateRoomDTO dto)
        {
            var success = await _service.UpdateRoomAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        /// <summary>
        /// Supprime une salle.
        /// </summary>
        /// <param name="id">L'identifiant de la salle à supprimer.</param>
        /// <response code="204">Suppression effectuée avec succès.</response>
        /// <response code="404">Si aucune salle correspondante n’est trouvée.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteRoomAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
