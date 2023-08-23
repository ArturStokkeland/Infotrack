using InfoTrack.Data;
using InfoTrack.Models;

namespace InfoTrack.Services
{
    public class HistoryService : IHistoryService
    {

        private readonly AppDbContext _context;

        public HistoryService(AppDbContext context)
        {
            _context = context;
        }

        public List<ScrapeResult> GetHistory() {
            var data = _context.ScrapeResults.OrderByDescending(result => result.SearchDate).ToList();
            return data;
        }
    }
}
