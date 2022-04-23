using System.ComponentModel.DataAnnotations;

namespace ArtGalleryAPI.Entities
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string UserRole { get; set; }

        public bool IsEditor { get; set; }

        public bool IsBannded { get; set; }

        public List<Post> Posts { get; set; }
    }
}
