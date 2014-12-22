using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace IMDB.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
    }
}