using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    /// <summary>
    /// Contrôleur de test pour vérifier le middleware de gestion des exceptions.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestMiddlewareController : ControllerBase
    {
        /// <summary>
        /// Lance une exception pour tester le middleware de gestion des erreurs.
        /// </summary>
        /// <remarks>
        /// Cette action est utilisée pour simuler une erreur et permettre de vérifier que le middleware intercepte l'exception
        /// et retourne une réponse d'erreur uniformisée.
        /// </remarks>
        /// <returns>Ne retourne pas de résultat normal car l'action lance une exception.</returns>
        /// <response code="500">Une erreur interne est retournée par le middleware d'exception.</response>
        [HttpGet("throw")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ThrowError()
        {
            // Pour tester le middleware, une exception est volontairement lancée.
            throw new Exception("Erreur de test pour vérifier le middleware.");
        }
    }
}
