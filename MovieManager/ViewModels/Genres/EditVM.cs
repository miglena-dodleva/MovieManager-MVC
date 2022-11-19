using System.ComponentModel.DataAnnotations;


namespace MovieManager.ViewModels.Genres
{
    public class EditVM: CreateVM
    {
        [Key]
        public int Id { get; set; }
    }
}
