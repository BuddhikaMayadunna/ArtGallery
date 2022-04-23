using ArtGalleryAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArtGalleryAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<StatVowels> StatVowels { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.SeedUsers(modelBuilder);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            User user1 = new User()
            {
                UserId = "shakes",
                PasswordHash = "1255376235",
                FirstName = "William",
                LastName = "Shakespear",
                EmailAddress = "will@theshakes.mnd",
                UserRole = "M",
                IsEditor = false,
                IsBannded = false
            };

            User user2 = new User()
            {
                UserId = "maups",
                PasswordHash = "1255376235",
                FirstName = "Guy De",
                LastName = "Maupesant",
                EmailAddress = "mau@paro.mnd",
                UserRole = "U",
                IsEditor = false,
                IsBannded = false
            };
            User user3 = new User()
            {
                UserId = "mws",
                PasswordHash = "1255376235",
                FirstName = "Martin",
                LastName = "Wickramasinghe",
                EmailAddress = "simon@kaballana.mnd",
                UserRole = "U",
                IsEditor = true,
                IsBannded = false
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            passwordHasher.HashPassword(user1, "Admin*123");
            builder.Entity<User>().HasData(user1);
            passwordHasher.HashPassword(user2, "Admin*123");
            builder.Entity<User>().HasData(user2);
            passwordHasher.HashPassword(user3, "Admin*123");
            builder.Entity<User>().HasData(user3);
        }

        public async Task<int> SaveAsync()
        {
            var addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();
            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted || e.State == EntityState.Modified).ToList();
            return await base.SaveChangesAsync();
        }
    }
}
