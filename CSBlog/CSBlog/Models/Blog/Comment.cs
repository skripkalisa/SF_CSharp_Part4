using System.ComponentModel.DataAnnotations;

namespace CSBlog.Models.Blog;

public class Comment
{
  public Guid Id { get; set; } = Guid.NewGuid();
  public Guid ArticleId { get; set; }
  public Guid UserId { get; set; }
  [Required (ErrorMessage = "This field is required.")]
  [StringLength(2048)]
  public string Text { get; set; } = string.Empty;
  public DateTime Added { get; set; } = DateTime.Now;
  public DateTime Changed { get; set; }
}