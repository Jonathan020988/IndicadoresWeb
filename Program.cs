using Microsoft.EntityFrameworkCore;
using IndicadoresWeb.Data; // Importar la carpeta donde está ApplicationDbContext

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configurar el pipeline de middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
