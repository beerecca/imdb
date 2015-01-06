using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class MovieRepository
    {
        private ImdbContext db = new ImdbContext();

        public List<Movie> GetMovies(int id = 0, string title = null, string genre = null)
        {
            if (id != 0)
            {
                return db.Movies.Where(r => r.Id == id).ToList();
            }
            else if (!string.IsNullOrEmpty(title))
            {
                return db.Movies.Where(s => s.Title.Contains(title)).ToList();
            }
            else if (!string.IsNullOrEmpty(genre))
            {
                return db.Movies.Where(x => x.Genres.Any(y => y.Name.Contains(genre))).ToList();
            }
            else
            {
                return db.Movies.ToList();
            }
        }
    }
}