using InfoTrack.Models;
using InfoTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScrapeController : ControllerBase
    {

        private IScrapeService _scrapeService;

        public ScrapeController(IScrapeService scrapeService) {
            _scrapeService = scrapeService;
        }

        [HttpPost(Name = "GetScrapeResult")]
        [Route("{engine}/{query}")]
        public async Task<ScrapeResult> Get(string engine, string query) {
            var result = await _scrapeService.ScrapeURL(engine, query);
            return result;
        }
    }
}
