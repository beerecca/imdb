using System.Web.Mvc;
using IMDB.Models;
using IMDB.ViewModels;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieRepository _movieRepository = new MovieRepository();
        private readonly GenreRepository _genreRepository = new GenreRepository();

        public ActionResult Index(string genre, string search)
        {
            var viewModel = new MovieActorData
            {
                Movies = _movieRepository.GetMovies(),
                GenreList = _genreRepository.GetGenreNames()
            };

            if (!string.IsNullOrEmpty(search))
            {
                viewModel.Movies = _movieRepository.GetMovies(title: search); 
            }

            if (!string.IsNullOrEmpty(genre))
            {
                viewModel.Movies = _movieRepository.GetMovies(genre: genre);
            }

            return View(viewModel); 
        }

        public ActionResult DetailsPartial(int movieId)
        {
            var viewModel = new MovieActorData
            {
                Movies = _movieRepository.GetMovies(movieId)
            };

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