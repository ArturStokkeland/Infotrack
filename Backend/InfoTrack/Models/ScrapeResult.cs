using System.ComponentModel.DataAnnotations;

namespace InfoTrack.Models
{
    public class ScrapeResult
    {
        [Key]
        public int Id { get; set; }
        public string? SearchTerm { get; set; }
        public string? SearchEngine { get; set; }
        public string? Result { get; set; }
        public DateTime SearchDate { get; set; }
    }
}