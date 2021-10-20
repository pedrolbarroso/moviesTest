using Microsoft.EntityFrameworkCore;
using MoviesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesTest
{
  public class MovieFixture : IDisposable
  {
    
    public DatabaseContext dataBaseContext { get; private set; }

    public MovieFixture()
    {

      var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
      dataBaseContext = new DatabaseContext(optionsBuilder.UseInMemoryDatabase("database").Options);
      dataBaseContext.SaveChanges();
    }

    public void Dispose()
    {
      dataBaseContext.Dispose();
    }
  }
}
