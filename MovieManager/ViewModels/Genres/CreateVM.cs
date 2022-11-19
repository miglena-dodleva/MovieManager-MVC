using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MovieManager.ViewModels.Genres
{
    public class CreateVM
    {
        [DisplayName("Name")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
    }
}
