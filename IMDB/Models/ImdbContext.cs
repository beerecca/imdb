using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace IMDB.Models
{
    public class ImdbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}