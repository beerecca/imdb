using System.Data.Entity;

namespace IMDB.Models
{
    public class ImdbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}