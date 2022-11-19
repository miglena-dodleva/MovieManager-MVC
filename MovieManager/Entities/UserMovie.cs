using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManager.Entities
{
    public class UserMovie
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Select User")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        [DisplayName("Select Movie")]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }
    }
}
