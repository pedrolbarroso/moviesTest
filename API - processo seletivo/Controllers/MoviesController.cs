using Microsoft.AspNetCore.Mvc;

namespace API___processo_seletivo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoviesController : ControllerBase
  {
    private readonly DatabaseContext _dbContext;
    public MoviesController(DatabaseContext db)
    {
      _dbContext = db;
      var hasMovies = _dbContext.Movies.Any();
      if (!hasMovies)
      {
        //Lê CSV e Grava no banco
        var helper = new Helpers();
        var moviesInCSV = helper.ReadCSV();


        _dbContext.Movies.AddRange(moviesInCSV);
        _dbContext.SaveChanges();
      }
    }

    // GET: api/<MoviesController>
    [HttpGet]
    public IEnumerable<Movie> Get()
    {
      return _dbContext.Movies.ToList();
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public Movie Get(Guid id)
    {
      return _dbContext.Movies.FirstOrDefault(movie => movie.ID.Equals(id));
    }

    [Route("api/MoviesController/GetByTitle")]
    [HttpGet]
    public Movie GetByTitle(string title)
    {
      return _dbContext.Movies.FirstOrDefault(movie => movie.Title.Equals(title));
    }


    // GET api/<MoviesController>/IntervaloPremios
    [Route("api/MoviesController/IntervaloPremios")]
    [HttpGet]
    public ActionResult IntervaloPremios()
    {
      var movies = _dbContext.Movies.Where(winner => winner.Winner.Equals("yes")).OrderBy(movie => movie.Year).ToList();

      var firstTwiceWinner = new
      {
        producer = "",
        interval = "",
        previouswin = "",
        followingWin = ""
      };

      var producerWinners = new List<Producer>();

      foreach (var movie in movies)
      {

        String[] separator = { ",", " and " };
        var movieProducers = movie.Producers.Trim().Split(separator, StringSplitOptions.RemoveEmptyEntries);

        for (var i = 0; i < movieProducers.Length; i++)
        {
          var producerName = movieProducers[i].Trim();
          if (producerWinners.Any(p => p.Name.Equals(producerName)))
          {
            producerWinners.FirstOrDefault(p => p.Name.Equals(producerName)).Years.Add(movie.Year);
            var firstWin = producerWinners.FirstOrDefault(p => p.Name.Equals(producerName));

            if (String.IsNullOrEmpty(firstTwiceWinner.producer))
            {
              firstTwiceWinner = new
              {
                producer = producerName,
                interval = (movie.Year - firstWin.Years.FirstOrDefault()).ToString(),
                previouswin = firstWin.Years.FirstOrDefault().ToString(),
                followingWin = movie.Year.ToString()
              };
            }
          }
          else
          {
            var years = new List<int>();
            years.Add(movie.Year);

            producerWinners.Add(new Producer { Name = producerName, Years = years });
          }
        }
      }

      var maxInterval = producerWinners.Max(p => p.Years.Max() - p.Years.Min());
      var maxIntervalWinner = producerWinners.First(p => (p.Years.Max() - p.Years.Min()) == maxInterval);

      var retorno = new
      {
        min = new[] { firstTwiceWinner },
        max = new[] {
          new
          {
            producer = maxIntervalWinner.Name,
            interval = maxInterval.ToString(),
            previouswin = maxIntervalWinner.Years.Min().ToString(),
            followingWin = maxIntervalWinner.Years.Max().ToString(),
          }}
      };

      return Ok(retorno);
    }

    // POST api/<MoviesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<MoviesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<MoviesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
