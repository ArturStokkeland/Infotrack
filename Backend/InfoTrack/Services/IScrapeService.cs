using InfoTrack.Models;

namespace InfoTrack.Services
{
    public interface IScrapeService
    {
        Task<ScrapeResult> ScrapeURL(string engine, string query);
    }
}
