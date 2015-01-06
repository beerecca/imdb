using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IMDB.Models;

namespace IMDB.ViewModels
{
    public class MovieActorData
    {
        public List<Movie> Movies { get; set; }
        public List<string> GenreList { get; set; }
    }
}