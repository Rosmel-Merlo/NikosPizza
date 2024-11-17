using Microsoft.OpenApi.Models;
using NikosPizza.Infraestructure;
using NikosPizza.Application;
using Microsoft.OpenApi.Models;
using NikosPizza.Infraestructure;
using NikosPizza.Application;
using NikosPizza.Api.Routes;
using Microsoft.AspNetCore.Identity;
using NikosPizza.core.Entities.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddApplicationServices(); // Agrega los servicios de la capa de aplicación
builder.Services.AddInfrectuctureServicePizza(builder.Configuration); // Agrega los servicios de la infraestructura

builder.Services.AddControllersWithViews(); // Habilita MVC y controladores con vistas
builder.Services.AddEndpointsApiExplorer(); // Habilita la exploración de endpoints para Swagger

// Configuración de Swagger para documentar la API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NikosPizza.API", Version = "v1" });
});

// Configuración de ASP.NET Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<PizzaDbContext>() // Usa el contexto de Entity Framework para almacenar usuarios
    .AddDefaultTokenProviders(); // Agrega proveedores de tokens predeterminados para cosas como restablecimiento de contraseñas

// Agregar autenticación y autorización
builder.Services.AddAuthentication(); // Configuración básica de autenticación
builder.Services.AddAuthorization();  // Configuración de autorización

// Habilitar servicios de HTTP para llamadas externas (opcional)
builder.Services.AddHttpClient();

var app = builder.Build();

// Configurar el pipeline de procesamiento de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    // Habilita Swagger solo en modo de desarrollo
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NikosPizza.API v1"));
}

// Servir archivos estáticos (CSS, JS, imágenes)
app.UseStaticFiles();

app.UseRouting();

// Habilitar autenticación y autorización en el pipeline
app.UseAuthentication(); // <- Agrega esta línea para asegurarte de que la autenticación esté habilitada
app.UseAuthorization();

// Configuración de las rutas
RouteConfig.RegisterRoutes(app);

app.MapControllers();
app.Run();
