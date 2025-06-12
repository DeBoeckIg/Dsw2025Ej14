using System.Text.Json;
using Dsw2025Ej14.Api.Domain.Entities;
using Dsw2025Ej14.Api.Domain.Interfaces;

namespace Dsw2025Ej14.Api.Data
{
    public class PersitenciaEnMemoria : IPersistencia
    {
        private List<Product> _products = new();

        public List<Product> GetAllActiveProducts()
        {
            throw new NotImplementedException();
        }

        public Product? GetBySku(string sku)
        {
            throw new NotImplementedException();
        }

        public void LoadProducts()
        {
            var json = File.ReadAllText("data\\products.json");
            _products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            }) ?? [];
        }
    }
}
