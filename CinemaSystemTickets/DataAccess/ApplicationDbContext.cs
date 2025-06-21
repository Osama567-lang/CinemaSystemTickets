using CinemaSystemTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaSystemTickets.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Actor>? Actors { get; set; }
        public DbSet<ActorMovie>? ActorMovies { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Cinema>? Cinemas { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;" +
                "initial catalog = CinemaSystemTickets; " +
                "Integrated Security=True;" +
                "TrustServerCertificate=True"
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ActorMovie>()
                .HasKey(am => new { am.ActorID, am.MovieId });

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorID);

            modelBuilder.Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.ActorMovies)
                .HasForeignKey(am => am.MovieId);
        }
    }
}
