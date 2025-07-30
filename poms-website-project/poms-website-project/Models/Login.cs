using System.ComponentModel.DataAnnotations;

namespace poms_website_project.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Email or LRN is Required.")]
        [Display(Name = "Email or LRN")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }


    }
}
