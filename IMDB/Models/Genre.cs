using System.Collections.Generic;

namespace IMDB.Models
{
    public class Genre : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}