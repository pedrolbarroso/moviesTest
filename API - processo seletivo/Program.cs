using API___processo_seletivo;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MoviesLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<MoviesServices>();

builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new() { Title = "API___processo_seletivo", Version = "v1" });
});

builder.Services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("database"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API___processo_seletivo v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

