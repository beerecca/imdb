using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class GenreRepository : BaseRepository<Genre>
    {

        public List<string> GetGenreNames()
        {
            return db.Genres.Select(genre => genre.Name).Distinct().ToList();
        }
    }
}