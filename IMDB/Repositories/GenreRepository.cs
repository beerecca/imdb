using System.Collections.Generic;
using System.Linq;
using IMDB.Models;

namespace IMDB.Repositories
{
    public class GenreRepository : BaseRepository<Genre>
    {
        public List<string> GetGenreNames()
        {
            return db.Genres.Select(genre => genre.Name).Distinct().ToList();
        }
    }
}