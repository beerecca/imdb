using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class MovieActorData
    {
        public IQueryable<Movie> Movies { get; set; } //rargh this was the bastard!
        public IEnumerable<Actor> Actors { get; set; }
    }
}