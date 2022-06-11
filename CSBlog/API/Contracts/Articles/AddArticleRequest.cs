using API.Contracts.Tags;

namespace API.Contracts.Articles;

public class AddArticleRequest
{
  public string Author { get; set; } = string.Empty;

  // [Required (ErrorMessage = "This field is required.")]
  // [StringLength(64)]
  public string? Title { get; set; }

  // [Required (ErrorMessage = "This field is required.")]
  public string? Text { get; set; }

  public ICollection<TagView> Tags { get; set; }
  // public ICollection<string> Tags { get; set; }
}