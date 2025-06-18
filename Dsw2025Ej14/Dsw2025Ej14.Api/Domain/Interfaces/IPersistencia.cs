using Dsw2025Ej14.Api.Domain.Entities;

namespace Dsw2025Ej14.Api.Domain.Interfaces
{
    public interface IPersistencia
    {
        List<Product> GetAllActiveProducts();
        Product? GetBySku(string sku);
    }
}
