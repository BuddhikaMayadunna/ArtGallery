using System.ComponentModel.DataAnnotations;

namespace ArtGalleryClient.Models
{
    public class PostViewModel
    {
        public string PostId { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }
    }
}
