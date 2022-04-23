using System.ComponentModel.DataAnnotations;

namespace ArtGalleryAPI.Entities
{
    public class Post
    {
        [Key]
        public string PostId { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public StatVowels StatVowels { get; set; }
    }
}
