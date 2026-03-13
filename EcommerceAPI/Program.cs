using EcommerceAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 1. Rejestracja Kontrolerów + Ignorowanie zapętleń w JSON (ważne przy relacjach)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// 2. Konfiguracja Bazy Danych SQLite
builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlite("Data Source=ecommerce.db"));

// 3. Dodanie Swaggera
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 4. Konfiguracja potoku żądań (Middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce API V1");
        c.RoutePrefix = string.Empty; // Swagger odpali się od razu po wejściu na localhost
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 5. TO JEST KLUCZOWE: Mapowanie kontrolerów na ścieżki URL
app.MapControllers();

app.Run();