using System.Collections.Generic;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class MovieData
    {
        public List<Movie> Movies { get; set; }
        public List<string> GenreList { get; set; }
    }
}