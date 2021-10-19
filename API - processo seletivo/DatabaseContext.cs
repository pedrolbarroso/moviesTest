using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API___processo_seletivo
{
  public class DatabaseContext : DbContext
  {
    public DbSet<Movie> Movies { get; set; }

    public string DbPath { get; private set; }

    public DatabaseContext(DbContextOptions options) : base(options)    {   }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      this.SeedMovies(builder);



    }

    private void SeedMovies(ModelBuilder builder)
    {
      //Lê CSV e Grava no banco
      var helper = new Helpers();
      var movies = helper.ReadCSV();

      foreach (var movie in movies)
      {
        builder.Entity<Movie>().HasData(movie);
        
      }
    }
  }

  public class Movie
  {
    public Guid ID { get; set; }
    public int Year { get; set; }
    public string Title { get; set; }
    public string Studios { get; set; }
    public string Producers { get; set; }
    public string Winner { get; set; }
  }
}