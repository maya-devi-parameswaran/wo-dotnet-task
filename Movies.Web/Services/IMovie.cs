using System.Threading.Tasks;

namespace Movies.Web.Services
{
    public interface IMovie
    {
        Task<string> DownloadApiDataAsync(string searchQuery);
    }
}
