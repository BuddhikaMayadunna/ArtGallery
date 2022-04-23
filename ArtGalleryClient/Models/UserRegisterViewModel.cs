//using Microsoft.Build.Framework;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtGalleryClient.Models
{
    public class UserRegisterViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Usename is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "User Id is required.")]
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
