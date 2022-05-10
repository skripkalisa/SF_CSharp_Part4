using System.ComponentModel.DataAnnotations;

namespace CSBlog.Models.Blog;

public class Tag
{
  // internal List<string> Tags { get; set; }
  public Guid Id { get; set; } = Guid.NewGuid();
  [Required (ErrorMessage = "This field is required.")]
  [StringLength(32)]
  public string TagName { get; set; } = String.Empty;
}