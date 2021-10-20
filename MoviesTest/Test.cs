using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MoviesLibrary;
using System.IO;

namespace MoviesTest
{ 
  public class TestStartup : Program
  {
    public TestStartup(IWebHostEnvironment env)
    {

      var builder = WebApplication.CreateBuilder();

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


    }
    //public void ConfigureTestServices(IServiceCollection services)
    //{
    //  services.Replace(ServiceDescriptor.Scoped<ITestService, TestService>());
    //  services.Replace(ServiceDescriptor.Scoped<ITestRepository, TestRepository>());
    //}
  }

  public class Main(string args)
  {

  }
}