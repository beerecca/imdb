using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class GenreRepository
    {
        private ImdbContext db = new ImdbContext();

        public List<Genre> GetGenres()
        {
            return db.Genres.ToList();
        }
    }
}