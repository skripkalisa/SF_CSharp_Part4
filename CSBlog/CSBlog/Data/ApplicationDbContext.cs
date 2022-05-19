using CSBlog.Models.Blog;
using CSBlog.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSBlog.Data;

public sealed class ApplicationDbContext : IdentityDbContext<BlogUser>
{
  public DbSet<BlogUser> BlogUsers { get; set; } = null!;

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

    modelBuilder.ApplyConfiguration(new BlogUserEntityConfiguration());
  }
}

public class BlogUserEntityConfiguration : IEntityTypeConfiguration<BlogUser>
{
  public void Configure(EntityTypeBuilder<BlogUser> builder)
  {
    builder.Property(u => u.FirstName).HasMaxLength(32);
    builder.Property(u => u.LastName).HasMaxLength(32);

  }
}