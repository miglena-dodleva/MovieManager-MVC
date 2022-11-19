using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MovieManager.ViewModels.Home
{
    public class LoginVM
    {
        [DisplayName("Username")]
        [StringLength(40, MinimumLength = 2)]
        public string Username { get; set; }

        [DisplayName("Password")]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
