using System.Collections.Generic;

namespace IMDB.Models
{
    public class Actor : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}

