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
            // Asegúrate de que los productos estén cargados
            if (_products == null)
            {
                LoadProducts(); // Llama a tu método de carga
            }

            // Filtra productos activos (si aplica) o devuelve todos
            return _products.Where(p => p.IsActive).ToList(); // Si tienes propiedad IsActive
                                                              // O simplemente:
                                                              // return _products; // Si no necesitas filtrar
        }

        public Product? GetBySku(string sku)
        {
            return _products.Where(predicate => predicate.Sku == sku).FirstOrDefault(); 
        
        }

        public void LoadProducts()
        {
            string fullPath = @"C:\Users\Ignacio\OneDrive - frt.utn.edu.ar\Desarrollo de Software\Practica\Unidad 3\Dsw2025Ej14\products.json";
            var json = File.ReadAllText(fullPath);
            _products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            }) ?? [];
        }
    }
}
