using System.Collections.Generic;
using System.Linq;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class MovieActorData
    {
        public IQueryable<Movie> Movies { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}