using InfoTrack.Models;

namespace InfoTrack.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                if (!context.ScrapeResults.Any()) {
                    context.ScrapeResults.AddRange(new List<ScrapeResult>() {
                        new ScrapeResult() {
                            SearchTerm = "land registry search",
                            SearchEngine = "Google",
                            Result = "1, 2, 3",
                            SearchDate = DateTime.Now
                        },
                        new ScrapeResult() {
                            SearchTerm = "land registry search",
                            SearchEngine = "Bing",
                            Result = "4, 5",
                            SearchDate = DateTime.Now
                        },
                        new ScrapeResult() {
                            SearchTerm = "land registry search",
                            SearchEngine = "Google",
                            Result = "10, 20",
                            SearchDate = DateTime.Now
                        },
                        new ScrapeResult() {
                            SearchTerm = "land registry search",
                            SearchEngine = "Google",
                            Result = "100",
                            SearchDate = DateTime.Now
                        },
                        new ScrapeResult() {
                            SearchTerm = "land registry search",
                            SearchEngine = "Bing",
                            Result = "50, 51",
                            SearchDate = DateTime.Now
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
