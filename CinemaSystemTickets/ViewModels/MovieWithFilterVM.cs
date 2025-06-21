using CinemaSystemTickets.Models;

namespace CinemaSystemTickets.ViewModels
{
    public class MovieWithFilterVM
    {
        public string MovieName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MovieStatus? MovieStatus { get; set; }
        public int? CategoryId { get; set; }
    }
}
