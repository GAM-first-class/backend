using Microsoft.EntityFrameworkCore;
using ModShop.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ModShopDbContext>(options =>
    {
        options.UseSqlServer("Server=.;Database=ModShopDb;Trusted_Connection=True;TrustServerCertificate=True;");
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
