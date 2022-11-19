using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Name")]
        [StringLength(100, MinimumLength = 3)]
        [Required]

        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
