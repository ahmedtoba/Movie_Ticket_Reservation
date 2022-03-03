using System.ComponentModel.DataAnnotations;

namespace MovieTickets.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Email or UserName")]
        public string Userlogin { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
