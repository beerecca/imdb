using System.Collections.Generic;
using System.Linq;
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

            var viewModel = new MovieActorData
            {
                Movies = db.Movies
                    .Include(i => i.Actors)
            };


            var genreLst = new List<string>();

            var genreQry = from d in db.Movies
                orderby d.Genre
                select d.Genre;

            genreLst.AddRange(genreQry.Distinct());
            ViewBag.genre = new SelectList(genreLst);   


            if (!string.IsNullOrEmpty(search))
            {
                viewModel.Movies = viewModel.Movies.Where(s => s.Title.Contains(search));
            }

            if (!string.IsNullOrEmpty(genre))
            {
                viewModel.Movies = viewModel.Movies.Where(x => x.Genre == genre);
            }

            return View(viewModel); 
        }

        public ActionResult DetailsPartial(string movieId)
        {
            var viewModel = new MovieActorData
            {
                Movies = db.Movies
                    .Include(i => i.Actors)
            };

            if (!string.IsNullOrEmpty(movieId))
            {
                var lookupId = int.Parse(movieId);
                viewModel.Movies = viewModel.Movies.Where(r => r.Id == lookupId);
            }

            return PartialView("DetailsPartial", viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}