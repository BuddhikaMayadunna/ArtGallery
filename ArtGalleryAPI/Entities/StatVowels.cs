using System.ComponentModel.DataAnnotations;

namespace ArtGalleryAPI.Entities
{
    public class StatVowels
    {
        [Key]
        public Guid StatId { get; set; }

        public DateTime Date { get; set; }

        public int SingleVowelCount { get; set; }

        public int PairVowelCount { get; set; }

        public int TotalWordCount { get; set; }

        public string PostId { get; set; }
        public Post UserPost { get; set; }
    }
}
