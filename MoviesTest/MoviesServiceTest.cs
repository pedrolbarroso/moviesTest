using MoviesLibrary;
using Xunit;
using Moq;
using API___processo_seletivo.Controllers;

namespace MoviesTest
{
  public class MoviesServiceTest : IClassFixture<MovieFixture>
  {
    private MovieFixture _movieFixture;
    public MoviesServiceTest(MovieFixture movieFixture)
    {
      _movieFixture = movieFixture;
    }

    [Fact]
    public void TestDatabase()
    {

      var helper = new Helpers();
      var movies = helper.ReadCSV();
      _movieFixture.dataBaseContext.Movies.AddRange(movies);
      _movieFixture.dataBaseContext.SaveChanges();

      bool databaseValid = true;
      foreach(var movie in movies)
      {
        if (_movieFixture.dataBaseContext.Movies.Find(movie.ID) == null)
        {
          databaseValid = false;   
        }
      }

      Assert.True(databaseValid);
    }
  }
}