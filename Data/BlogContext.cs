using Blogging_web.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blogging_web.Data
{
    public class BlogContext : DbContext

    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {


        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> BlogPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.LogTo(Console.WriteLine);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Email = "20101001-086@uskt.edu.pk",
                        FirstName = "Ali",
                        LastName = "Zain",
                        Salt = "azg",
                        Hash = "azgondal/="
                    }
                );
        }
    }
}
