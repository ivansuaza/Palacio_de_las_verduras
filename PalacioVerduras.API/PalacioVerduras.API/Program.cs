using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PalacioVerduras.API.Services;
using PalacioVerduras.API.Utilities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;  
using PalacioVerduras.API.Data;     
using Microsoft.Extensions.Configuration;

namespace PalacioVerduras.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PalacioVerduras.API - Gestión de Ventas y Productos",
                    Version = "v1",
                    Description = "Esta API permite gestionar clientes, empleados, productos y ventas en el Palacio de las Verduras.",
                    Contact = new OpenApiContact
                    {
                        Name = "Equipo de Desarrollo",
                        Email = "email@example.com",
                        Url = new Uri("https://www.example.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Uso bajo Licencia Ejemplo",
                        Url = new Uri("https://www.example.com/license")
                    }
                });
            });


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

    }

}

    