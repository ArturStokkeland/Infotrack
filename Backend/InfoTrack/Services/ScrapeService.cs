using InfoTrack.Data;
using InfoTrack.Models;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using static System.Net.WebRequestMethods;

namespace InfoTrack.Services
{
    public class ScrapeService : IScrapeService
    {

        private AppDbContext _context;

        public ScrapeService(AppDbContext context) {
            _context = context;
        }

        private string generateURL(string engine, string keywords) {

            string query = "";
            
            if (engine == "google") {
                query = "https://www.google.co.uk/search?num=100&q=" + string.Join("+", keywords.Split(" "));
            }
            else if (engine == "bing") {
                query = "https://www.bing.com/search?count=50&responseFilter=Webpages&q=" + string.Join("+", keywords.Split(" "));
            }

            return query;

        }

        private async Task<string> getScrapeResult(string query) {

            var myQuery = new Uri(query);
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = myQuery }) { 
                cookieContainer.Add(myQuery, new Cookie("CONSENT", "YES+"));
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                var result = await client.GetStringAsync("");
                return result;
            }
            
        }

        private string getRankings(string result) {
            var allLinks = Regex.Matches(result, "https://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?");
            string allMatches = "";
            int i = 1;
            foreach (Match match in allLinks) {
                if (match.Value.Contains("google.co") || match.Value.Contains("bing.co") || match.Value.Contains("microsoft.co")) {
                    continue;
                }
                if(match.Value.Contains("infotrack.co.uk")) {
                    if (allMatches == "") {
                        allMatches += i;
                    }
                    else {
                        allMatches += ", " + i;
                    }
                }
           
                i++;
            }
            return allMatches;
        }

        private async Task addToDB(ScrapeResult myResult) {
            await _context.ScrapeResults.AddAsync(
                new ScrapeResult() {
                    SearchTerm = myResult.SearchTerm,
                    SearchEngine = myResult.SearchEngine,
                    Result = myResult.Result,
                    SearchDate = myResult.SearchDate
                }
            );
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<ScrapeResult> ScrapeURL(string engine, string query) {
            string myQuery = generateURL(engine, query);
            string scrapeResult = await getScrapeResult(myQuery);
            string rankings = getRankings(scrapeResult);

            ScrapeResult myResult = new ScrapeResult() {
                SearchTerm = query,
                SearchEngine = engine,
                Result = rankings,
                SearchDate = DateTime.Now
            };

            await addToDB(myResult);

            return myResult;
        }
    }
}
