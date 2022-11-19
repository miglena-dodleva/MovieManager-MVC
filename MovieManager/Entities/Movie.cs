using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Title")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [DisplayName("Summary")]
        [StringLength(300, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Summary { get; set; }

        [DisplayName("Director")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Director { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required]
        public string ImageUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        [Required]
        public string TrailerUrl { get; set; }

        [DisplayName("Country")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Country { get; set; }

        [DisplayName("Duration")]
        [Range(0, (int.MaxValue), ErrorMessage = "Must be a positive number")]
        [Required]
        public int Duration { get; set; }


        [DisplayName("ReleaseDate")]
        [Range(1933, 2022, ErrorMessage = "Must be in this range")]
        [Required]
        public int ReleaseDate { get; set; }

        [DisplayName("Select Genre")]
        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
        public virtual ICollection<UserMovie> UserMovie { get; set; }
    }
}
