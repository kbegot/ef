using Microsoft.AspNetCore.Mvc;
using Tryhard.Models;
using Tryhard.Services;

namespace Tryhard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly MongoDBService _service;

        public ProductsController(MongoDBService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get() => _service.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Product> Get(string id)
        {
            var product = _service.Get(id);
            return product == null ? NotFound() : product;
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _service.Create(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Product product)
        {
            var existing = _service.Get(id);
            if (existing == null) return NotFound();

            product.Id = id;
            _service.Update(id, product);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var existing = _service.Get(id);
            if (existing == null) return NotFound();

            _service.Remove(id);
            return NoContent();
        }
    }
}
