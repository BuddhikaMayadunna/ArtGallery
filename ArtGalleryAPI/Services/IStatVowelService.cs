using ArtGalleryAPI.Models;

namespace ArtGalleryAPI.Services
{
    public interface IStatVowelService
    {
        Task<StatVowelModel> UpdateAsync(StatVowelModel model);
        Task<int> InsertAsync(StatVowelModel model);
    }
}
