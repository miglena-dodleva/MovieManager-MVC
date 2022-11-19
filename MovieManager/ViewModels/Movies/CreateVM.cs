
using MovieManager.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.ViewModels.Movies
{
    public class CreateVM
    {
        [DisplayName("Title")]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [DisplayName("Summary")]
        [StringLength(300, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }

        public string Director { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        public string TrailerUrl { get; set; }
        public string Country { get; set; }
        public int ReleaseDate { get; set; }

        public int Duration { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
