using System.ComponentModel.DataAnnotations;

namespace MovieTickets.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Username or Email Required")]
        [Display(Name ="Email or UserName")]
        public string UserLogin { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
