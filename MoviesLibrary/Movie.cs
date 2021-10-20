using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesLibrary
{
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
