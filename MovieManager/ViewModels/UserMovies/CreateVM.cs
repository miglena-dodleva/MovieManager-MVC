using MovieManager.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.ViewModels.UserMovies
{
    public class CreateVM
    {
        [DisplayName("Select User")]
        public int UserId { get; set; }

        [DisplayName("Select Movie")]
        public int MovieId { get; set; }

        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<UserMovie> UserMovies { get; set; }
    }
}
