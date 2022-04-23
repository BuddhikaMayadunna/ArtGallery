using ArtGalleryAPI.Models;

namespace ArtGalleryAPI.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostModel>> GetAsync();
        Task<PostModel> UpdateAsync(PostModel model);
        Task<int> InsertAsync(PostModel model);
        Task<int> DeleteAsync(PostModel model);
    }
}
