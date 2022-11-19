

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.ViewModels.Users
{
    public class CreateVM
    {
        [DisplayName("FirstName")]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        [StringLength(50, MinimumLength = 4)]
        public string LastName { get; set; }

        [DisplayName("Username")]
        [StringLength(40, MinimumLength = 2)]
        public string Username { get; set; }

        [DisplayName("Password")]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
