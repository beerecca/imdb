using System.Collections.Generic;
using System.Linq;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class MovieActorData
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}