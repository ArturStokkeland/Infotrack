using InfoTrack.Models;

namespace InfoTrack.Services
{
    public interface IHistoryService
    {
        List<ScrapeResult> GetHistory();
    }
}
