using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Web.Services
{
    public class MovieService : IMovie
    {
        private string baseUrl = "http://www.omdbapi.com/";
        private string apiKey = "&apikey=309902fd";
        public async Task<string> DownloadApiDataAsync(string searchQuery)
        {
            string movieJson = "";
            string url = baseUrl + "?s=" + searchQuery + apiKey;
            using (HttpClient hc = new HttpClient())
            {
                movieJson = await hc.GetStringAsync(url);

            }
            return movieJson;
        }
    }
}
