using System.ComponentModel.DataAnnotations;
using CSBlog.Models.User;

namespace CSBlog.Models.Blog;


public  class Article
{
  public Guid Id { get; set; }  = Guid.NewGuid();
  public Guid UserId { get; set; }

  public string? Author { get; set; } = String.Empty;

  [Required (ErrorMessage = "This field is required.")]
  [StringLength(64)]
  public string Title { get; set; } = string.Empty;
  [Required (ErrorMessage = "This field is required.")]
  public string Text { get; set; } = string.Empty;

  public List<Tag> Tags { get; set; } = new();
  public  List<Comment>? Comments { get; set; }
  public DateTime Published { get; set; }
  public DateTime Edited { get; set; }
}