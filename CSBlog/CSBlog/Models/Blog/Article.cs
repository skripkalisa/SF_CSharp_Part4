using System.ComponentModel.DataAnnotations;
namespace CSBlog.Models.Blog;


public class Article
{
  public Guid Id { get; set; }  = Guid.NewGuid();
  public Guid UserId { get; set; }

  public User.User Author { get; set; } = null!;

  [Required (ErrorMessage = "This field is required.")]
  [StringLength(64)]
  public string Title { get; set; } = string.Empty;
  [Required (ErrorMessage = "This field is required.")]
  public string Text { get; set; } = string.Empty;
  public List<Tag> Tags { get; set; } = null!;
  public List<Comment> Comments { get; set; } = null!;
  public DateTime Published { get; set; } = DateTime.Now;
  public DateTime Edited { get; set; }
}