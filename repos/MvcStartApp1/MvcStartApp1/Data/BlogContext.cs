using Microsoft.EntityFrameworkCore;
using MvcStartApp1.Models.Db;

namespace MvcStartApp1.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserPost> UserPosts { get; set; } = null!;
        public DbSet<Request> Requests { get; set; } = null!;
    }
}