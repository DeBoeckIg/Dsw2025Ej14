using Microsoft.AspNetCore.Mvc;
using Dsw2025Ej14.Api.Domain.Interfaces;

namespace Dsw2025Ej14.Api.Controllers
{
    [ApiController] // atributo para saber que esto es un controlador de api, para que se mapee los endpoints
    [Route("api/[controller]")] //este es la ruta general para todos, es algo general, en cada uno de los httpGet
    public class ProductsController : ControllerBase
    {
        private readonly IPersistencia _persistencia;

        public ProductsController(IPersistencia persistencia)
        {
            _persistencia = persistencia;
        }

        [HttpGet] //es la buena practica rest/protocolo http/ teoria de enrutamiento
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
