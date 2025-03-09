using Blog.Domain.Models;
using Blog.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }
        // public DbSet<PostTag> PostTags { get; set; }
        // public DbSet<Role> Roles { get; set; }
        // public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }
        // public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new  UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }
    }
}
