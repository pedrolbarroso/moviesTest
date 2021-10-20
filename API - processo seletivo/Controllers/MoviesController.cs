using Microsoft.AspNetCore.Mvc;
using MoviesLibrary;

namespace API___processo_seletivo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MoviesController : ControllerBase
  {
    private readonly MoviesServices _service ;
    public MoviesController(MoviesServices service)
    {
      _service = service;
    }

    // GET: api/<MoviesController>
    [HttpGet]
    public IEnumerable<Movie> Get()
    {
      return _service.Get();
    }

    // GET api/<MoviesController>/5
    [HttpGet("{id}")]
    public Movie Get(Guid id)
    {
      return _service.Get(id);
    }

    [Route("api/MoviesController/GetByTitle")]
    [HttpGet]
    public Movie GetByTitle(string title)
    {
      return _service.GetByTitle(title);
    }


    // GET api/<MoviesController>/IntervaloPremios
    [Route("api/MoviesController/IntervaloPremios")]
    [HttpGet]
    public ActionResult IntervaloPremios()
    {
      var minMax = _service.GetMinMax();
      return Ok(minMax);
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
