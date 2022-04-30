using Microsoft.EntityFrameworkCore;

namespace CSBlog.Models.Blog;

public sealed class BlogContext : DbContext
{
  public DbSet<User.User> Users { get; set; } = null!;

  public DbSet<Article> Articles { get; set; } = null!;

  public DbSet<Comment> Comments { get; set; } = null!;
  
  public DbSet<Tag> Tags { get; set; } = null!;

  public BlogContext(DbContextOptions<BlogContext> options) : base(options)
  {
    Database.EnsureCreated();
  }

  // protected override void OnModelCreating(ModelBuilder modelBuilder)
  // {
  //   modelBuilder.Entity<User>().HasData(
  //     new User { Id = 1, Name = "Tom", Age = 37 },
  //     new User { Id = 2, Name = "Bob", Age = 41 },
  //     new User { Id = 3, Name = "Sam", Age = 24 }
  //   );
  // }
  
}