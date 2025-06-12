using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Dsw2025Ej14.Api.Data;
using Dsw2025Ej14.Api.Domain;
using Dsw2025Ej14.Api.Domain.Interfaces;

namespace Dsw2025Ej14.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IPersistencia _persistencia;

        public ProductsController(IPersistencia persistencia)
        {
            _persistencia = persistencia;
        }

        [HttpGet]
        public IActionResult GetAllActiveProducts()
        {
            var products = _persistencia.GetAllActiveProducts();

            if (products == null || !products.Any())
            {
                return NoContent(); // 204 si no hay productos activos
            }

            return Ok(products); // 200 con los productos
        }

        [HttpGet("{sku}")]
        public IActionResult GetProductBySku(string sku)
        {
            var product = _persistencia.GetBySku(sku);

            if (product == null)
            {
                return NotFound(); // 404 si no existe
            }

            return Ok(product); // 200 con el producto
        }
    }
}
