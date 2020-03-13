using Microsoft.AspNetCore.Mvc;
using Movies.Web.Models.Movies;
using Movies.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovie _movieService;
        public MoviesController(IMovie movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Index(string query)
        {
            if (string.IsNullOrEmpty(query)) return View();

            var json = await _movieService.DownloadApiDataAsync(query.Replace("query=", ""));
            var movies = JsonConvert.DeserializeObject<JObject>(json);
            SearchResults movieResults = new SearchResults();
            movieResults.Results = new List<SearchResult>();
            foreach (var movie in movies["Search"])
            {
                var movie2 = JsonConvert.DeserializeObject<SearchResult>(movie.ToString());
                movieResults.Results.Add(movie2);
            }

            return View(movieResults);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
