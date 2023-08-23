using InfoTrack.Models;
using InfoTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {
        private IHistoryService _historyService;

        public HistoryController(IHistoryService historyService) {
            _historyService = historyService;
        }

        [HttpGet(Name = "GetHistory")]
        public List<ScrapeResult> Get() {
            var result = _historyService.GetHistory();
            return result;
        }
    }
}
