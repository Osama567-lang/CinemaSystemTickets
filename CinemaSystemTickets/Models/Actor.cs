namespace CinemaSystemTickets.Models
{
    public class Actor
    {
        public int ActorID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string? ProfilePicture { get; set; } 
        public string News { get; set; } = string.Empty;
        public List<Movie>? Movies { get; set; }
        public List<ActorMovie>? ActorMovies { get; set; }
    }
}
