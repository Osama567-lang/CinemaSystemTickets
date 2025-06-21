﻿namespace CinemaSystemTickets.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CinemaLogo { get; set; }
        public string? Address { get; set; }
        public List<Movie>? Movies { get; set; }
    }
}
