using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB.Models
{
    public class MovieRepository
    {
        private ImdbContext db = new ImdbContext();

        public List<Movie> GetMovies()
        {

//            if (int id) //check through optional parameters and that jazz
//            {
//                return db.Movies.Where(r => r.Id == id).ToList();
//            }
//            else if (string title)
//            {
//                return db.Movies.Where(s => s.Title.Contains(title)).ToList();
//            }
//            else
//            {
                return db.Movies.ToList();
           // }
            
        }

        public List<Movie> GetMoviesById(int id)
        {
            return db.Movies.Where(r => r.Id == id).ToList();
        } 

        public List<Movie> GetMoviesByTitle(string title)
        {
            return db.Movies.Where(s => s.Title.Contains(title)).ToList();
        }

        public List<Movie> GetMoviesByGenre(string genre) //cant include this above cos it's two strings, c# wont know which one you're including?
        {
            return db.Movies.Where(x => x.Genres.Any(y => y.Name.Contains(genre))).ToList();
        }

    }
}