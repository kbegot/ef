using Microsoft.AspNetCore.Mvc;

namespace EventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestMiddlewareController : ControllerBase
    {
        [HttpGet("throw")]
        public IActionResult ThrowError()
        {
            // Pour tester le middleware d'exception 
            throw new Exception("Erreur de test pour vérifier le middleware.");
        }
    }
}
