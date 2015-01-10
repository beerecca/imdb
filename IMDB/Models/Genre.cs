using System.Collections.Generic;

namespace IMDB.Models
{
    public class Genre : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}