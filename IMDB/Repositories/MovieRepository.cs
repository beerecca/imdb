using System.Collections.Generic;
using System.Linq;
using IMDB.Models;

namespace IMDB.Repositories
{
    public class MovieRepository : BaseRepository<Movie>
    {
        public List<Movie> GetMovies()
        {
            return db.Movies.ToList();
        }

        public List<Movie> GetMoviesByTitle(string title)
        {
            return db.Movies.Where(s => s.Title.Contains(title)).ToList();
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            return db.Movies.Where(x => x.Genres.Any(y => y.Name.Contains(genre))).ToList();
        }
    }
}