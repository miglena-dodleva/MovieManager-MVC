using MovieManager.Entities;
using MovieManager.ViewModels.Pager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels.Genres
{
    public class IndexVM
    {
        public virtual ICollection<Genre> Genres { get; set; }
        public PagerVM Pager { get; set; }
    }
}
