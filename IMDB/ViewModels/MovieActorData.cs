using System.Collections.Generic;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class MovieActorData
    {
        public List<Movie> Movies { get; set; }
        public List<string> GenreList { get; set; }
    }
}