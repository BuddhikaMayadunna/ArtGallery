namespace ArtGalleryAPI.Models
{
    public class UserModel
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        /// <value>
        /// The password hash.
        /// </value>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        /// <value>
        /// The password salt.
        /// </value>
        public byte[] PasswordSalt { get; set; }
    }
}
