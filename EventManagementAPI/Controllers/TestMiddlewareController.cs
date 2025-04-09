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
            // For testing, throw an exception to see if the middleware catches it
            throw new Exception("Erreur de test pour vérifier le middleware.");
        }
    }
}
