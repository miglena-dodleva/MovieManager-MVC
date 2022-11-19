using MovieManager.Entities;
using MovieManager.ViewModels.Pager;
using System.Collections.Generic;
namespace MovieManager.ViewModels.Users
{
    public class IndexVM
    {
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UserMovie> UserMovies { get; set; }
        public PagerVM Pager { get; set; }
    }
}
