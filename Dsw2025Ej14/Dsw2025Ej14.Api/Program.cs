
using Dsw2025Ej14.Api.Domain.Interfaces;
using Dsw2025Ej14.Api.Data; // Asegúrate de tener este using
using Microsoft.AspNetCore.Mvc;

namespace Dsw2025Ej14.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ===== Configuración de servicios =====
            builder.Services.AddControllers();

            // Registra tu PersistenciaEnMemoria como Singleton
            builder.Services.AddSingleton<IPersistencia, PersitenciaEnMemoria>(provider =>
            {
                var persistence = new PersitenciaEnMemoria();
                persistence.LoadProducts(); // Carga los productos desde el JSON
                return persistence;
            });

            // Swagger (opcional, pero útil para probar la API)
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ===== Configuración del pipeline HTTP =====
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
