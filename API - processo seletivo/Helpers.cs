namespace API___processo_seletivo
{
  public class Helpers
  {
    public List<Movie> ReadCSV()
    {
      using (var reader = new StreamReader(@"D:\movielist.csv"))
      {
        List<Movie> movies = new List<Movie>();
        bool firstline = true;
        while (!reader.EndOfStream)
        {
          var line = reader.ReadLine();
          
          if (firstline == true)
          {
            firstline = false;
            continue;
          }

          var values = line.Split(';');
          movies.Add(new Movie { ID = Guid.NewGuid(),Year = int.Parse(values[0]), Title = values[1], Studios = values[2], Producers = values[3], Winner = values[4]});
        }

        return movies;
      }
    }
  }
}
