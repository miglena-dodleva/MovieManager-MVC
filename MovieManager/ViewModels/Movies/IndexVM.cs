using MovieManager.Entities;
using MovieManager.ViewModels.Pager;
using System.Collections.Generic;

namespace MovieManager.ViewModels.Movies
{
    public class IndexVM
    {
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public PagerVM Pager { get; set; }
    }
}
