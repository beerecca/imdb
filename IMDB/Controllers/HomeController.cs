using System.Linq;
using System.Web.Mvc;
using IMDB.Models;
using IMDB.ViewModels;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        private MovieRepository movieRepository = new MovieRepository();
        private GenreRepository genreRepository = new GenreRepository(); //when should vars be an underscore? 

        public ActionResult Index(string genre, string search)
        {
            var viewModel = new MovieActorData
            {
                Movies = movieRepository.GetMovies()
            }; //repeating this, can put as private on the class?

            var genreList = genreRepository.GetGenres().Distinct().ToArray();
            ViewBag.genre = new SelectList(genreList);   //can we get refactor out the viewbag?


            if (!string.IsNullOrEmpty(search))
            {
                viewModel.Movies = movieRepository.GetMoviesByTitle(search); 
            }

            if (!string.IsNullOrEmpty(genre))
            {
                viewModel.Movies = movieRepository.GetMoviesByGenre(genre);
            }

            return View(viewModel); 
        }

        public ActionResult DetailsPartial(string movieId)
        {
            var viewModel = new MovieActorData
            {
                Movies = movieRepository.GetMovies()
            };

            if (!string.IsNullOrEmpty(movieId))
            {
                var lookupId = int.Parse(movieId);
                viewModel.Movies = movieRepository.GetMoviesById(lookupId);
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