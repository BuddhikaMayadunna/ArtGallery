using System.ComponentModel.DataAnnotations;

namespace ArtGalleryClient.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "UserName is required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
