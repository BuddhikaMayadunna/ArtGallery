using ArtGalleryAPI.Models;
using ArtGalleryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGalleryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public static UserModel user = new();

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<int>> RegisterAsync(UserRegisterModel request)
        {
            var user = await userService.RegisterUserAsync(request);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(AuthRequestModel request)
        {
            if (string.IsNullOrEmpty(request.Username))
                return BadRequest(TextResource.UserNotFound);

            if (!await userService.VerifyPasswordHashAsync(request))
                return BadRequest(TextResource.InvalidPasswardHash);

            var token = userService.GetToken(user);
            return Ok(token);
        }
    }
}
