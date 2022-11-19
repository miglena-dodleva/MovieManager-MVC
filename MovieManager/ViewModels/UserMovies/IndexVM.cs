
using MovieManager.Entities;
using MovieManager.ViewModels.Pager;
using System.Collections.Generic;


namespace MovieManager.ViewModels.UserMovies
{
    public class IndexVM
    {
        public virtual ICollection<UserMovie> UserMovies { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public PagerVM Pager { get; set; }
    }
}
