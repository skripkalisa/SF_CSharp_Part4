using System.ComponentModel.DataAnnotations;
using CSBlog.Models.Blog;

namespace CSBlog.Core.ViewModels.Blog;

public class CommentEditViewModel
{
  [Required]
  [Display(Name = "Your commentary")]
  [StringLength(1024, MinimumLength = 3, ErrorMessage = "Your commentary is too short or too long")]
  public string? Text { get; set; }
  public string? CommentId { get; set; }
  public string? ArticleId { get; set; }
  public Article? Article { get; set; }
}