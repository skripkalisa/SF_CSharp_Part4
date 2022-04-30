using CSBlog.Models.Blog;
using CSBlog.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSBlog.Data;

public sealed class ApplicationDbContext : IdentityDbContext
{
  public  DbSet<User> Users { get; set; } = null!;

  public DbSet<Article> Articles { get; set; } = null!;

  public DbSet<Comment> Comments { get; set; } = null!;

  public DbSet<Tag> Tags { get; set; } = null!;

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
  {
    Database.EnsureCreated();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Article>();
  }
}