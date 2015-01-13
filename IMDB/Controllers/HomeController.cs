using System.Linq;
using System.Web.Mvc;
using IMDB.Repositories;
using IMDB.ViewModels;

namespace IMDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieRepository _movieRepository = new MovieRepository();
        private readonly GenreRepository _genreRepository = new GenreRepository();

        public ActionResult Index(string search, string genre)
        {
            var searchFilter = _movieRepository.GetMoviesByTitle(search);
            var genreFilter = _movieRepository.GetMoviesByGenre(genre);

            var viewModel = new MovieData
            {
                Movies = _movieRepository.GetMovies(),
                GenreList = _genreRepository.GetGenreNames()
            };

            if (!string.IsNullOrEmpty(search))
            {
                viewModel.Movies = searchFilter; 
            }

            if (!string.IsNullOrEmpty(genre))
            {
                viewModel.Movies = genreFilter;
            }

            if (!string.IsNullOrEmpty(search) && !string.IsNullOrEmpty(genre))
            {
                viewModel.Movies = searchFilter.Intersect(genreFilter).ToList();
            }

            return View(viewModel); 
        }

        public ActionResult DetailsPartial(int movieId)
        {
            var viewModel = new MovieData
            {
               Movies = _movieRepository.GetById(movieId)
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