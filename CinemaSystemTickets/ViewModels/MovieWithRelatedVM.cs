using CinemaSystemTickets.Models;

namespace CinemaSystemTickets.ViewModels
{
    public class MovieWithRelatedVM
    {
        public Movie Movie { get; set; } = new();
        public List<Movie>? RelatedMovies { get; set; } = new();
        public List<Movie>? TopMovies { get; set; } = new();
        public List<Movie>? SimilarMovies { get; set; } = new();

        public List<Actor>? Actors { get; set; } = new(); 
    }
}
