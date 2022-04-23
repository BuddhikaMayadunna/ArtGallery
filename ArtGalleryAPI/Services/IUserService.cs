using ArtGalleryAPI.Models;

namespace ArtGalleryAPI.Services
{
    public interface IUserService
    {
        string GetUserName();

        string GetToken(UserModel user);

        Task<UserModel> RegisterUserAsync(UserRegisterModel request);

        Task<bool> VerifyPasswordHashAsync(AuthRequestModel request);
    }
}
