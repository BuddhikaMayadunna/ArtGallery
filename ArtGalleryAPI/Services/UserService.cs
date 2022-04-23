using ArtGalleryAPI.Entities;
using ArtGalleryAPI.Models;
using FlockAPI.Data.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace ArtGalleryAPI.Services
{
    public class UserService : IUserService
    {
        public static UserModel user = new();
        /// <summary>
        /// The HTTP context accessor
        /// </summary>
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// The configuration.
        /// </summary>
        private readonly IConfiguration configuration;

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWorkAsync unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">The HTTP context accessor.</param>
        /// <param name="configuration">The configuration.</param>
        public UserService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IUnitOfWorkAsync unitOfWork)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <returns>The User name.</returns>
        public string GetUserName()
        {
            var result = string.Empty;
            if (httpContextAccessor.HttpContext != null)
            {
                result = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }

        public async Task<UserModel> RegisterUserAsync(UserRegisterModel request)
        {
            user.Username = request.UserName;
            await CreatePasswordHashAsync(request.Password, user);

            var newUser = new User
            {
                UserId = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                UserRole = "U",
                IsEditor = false,
                IsBannded = false,
                PasswordHash = Encoding.UTF8.GetString(user.PasswordHash, 0, user.PasswordHash.Length)
            };

            unitOfWork.GetRepositoryAsync<User>().Insert(newUser);
            await unitOfWork.SaveAsync();
            return user;
        }

        private async Task<UserModel> CreatePasswordHashAsync(string password, UserModel user)
        {
            var passwordByteArray = Encoding.UTF8.GetBytes(password);
            using (var hmac = new HMACSHA512())
            {
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = await hmac.ComputeHashAsync(new MemoryStream(passwordByteArray));
            }
            return user;
        }
        public async Task<bool> VerifyPasswordHashAsync(AuthRequestModel request)
        {
            var passwordByteArray = Encoding.UTF8.GetBytes(request.Password);
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = await hmac.ComputeHashAsync(new MemoryStream(passwordByteArray));
                return computedHash.SequenceEqual(user.PasswordHash);
            }
        }

        public string GetToken(UserModel user)
        {
            return CreateToken(user);
        }

        private string CreateToken(UserModel user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
