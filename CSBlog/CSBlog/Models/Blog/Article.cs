using System.ComponentModel.DataAnnotations;
using CSBlog.Models.Blog;
using CSBlog.Models.User;

public class Article
{
  public Guid Id { get; set; } 
  public Guid UserId { get; set; }
  [Required]
  public User Author { get; set; }  = null!;
  [Required]
  public string Title { get; set; } = string.Empty;
  [Required]
  public string Text { get; set; } = string.Empty;
  public List<Tag> Tags { get; set; } = null!;
  public List<Comment> Comments { get; set; } = null!;
  public DateTime Published { get; set; }
  public DateTime Edited { get; set; }
}