using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMDB.Models;
using IMDB.ViewModels;
using System.Data.Entity;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        private ImdbContext db = new ImdbContext();

        public ActionResult Index(string genre, string search)
        {

            

            var genreLst = new List<string>(); //create new empty list

            var genreQry = from d in db.Movies
                orderby d.Genre
                select d.Genre; //get all genres from the db context . movie table

            genreLst.AddRange(genreQry.Distinct()); //add all distinct genres to the empty list
            ViewBag.genre = new SelectList(genreLst); //create a select list called genre


            var viewModel = new MovieActorData();

            viewModel.Movies = db.Movies
                .Include(i => i.Actors);



          //  var movies = from m in db.Movies
          //               select m; //create a data list of all movies

            if (!String.IsNullOrEmpty(search))
            {
                viewModel.Movies = viewModel.Movies.Where(s => s.Title.Contains(search)); //list of movies is constrained to where the title contains the search
            }

            if (!string.IsNullOrEmpty(genre))
            {
                viewModel.Movies = viewModel.Movies.Where(x => x.Genre == genre); //list of movies is constrained to the genre selected
            }

            return View(viewModel); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "IMDb, the world's most popular and authoritative source for movie, TV and celebrity content.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact me about this project.";

            return View();
        }
    }
}