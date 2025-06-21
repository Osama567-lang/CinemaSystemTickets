using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaSystemTickets.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [NotMapped]
        public MovieStatus MovieStatus
        {
            get
            {
                var current = DateTime.Now;

                if (EndDate < current.AddDays(-15))
                    return MovieStatus.Expired;
                else if (StartDate <= current && EndDate >= current)
                    return MovieStatus.Available;
                else if (StartDate > current && StartDate <= current.AddMonths(1))
                    return MovieStatus.Upcoming;
                else
                    return MovieStatus.Upcoming;
            }
        }



        public int CinemaID { get; set; }
        public int CategoryID { get; set; }

        public Cinema? Cinema { get; set; }
        public Category? Category { get; set; }

        public List<Actor>? Actors { get; set; }
        public List<ActorMovie>? ActorMovies { get; set; }
    }
}
