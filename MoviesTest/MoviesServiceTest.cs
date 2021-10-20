using MoviesLibrary;
using Xunit;
using Moq;
using API___processo_seletivo.Controllers;

namespace MoviesTest
{
  public readonly WebApplicationFactory
  public class MoviesServiceTest
  {
    [Fact]
    public void TestMinMax()
    {
      Moq.Mock<MoviesServices> servicesMock = new Moq.Mock<MoviesServices>();
      var moviesController = new MoviesController(servicesMock.Object);
      var service = new MoviesServices(mock.Object);
    
    }
  }
}