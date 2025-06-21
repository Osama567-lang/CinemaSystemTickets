namespace CinemaSystemTickets.Models
{
    public class ActorMovie
    {
        public int ActorID { get; set; }
        public Actor Actor { get; set; } = null!;

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}
