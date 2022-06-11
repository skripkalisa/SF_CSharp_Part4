using API.Contracts.Tags;

namespace API.Contracts.Articles;

public class GetArticlesResponse
{
  public int ArticlesTotal { get; set; }
  public List<ArticleView>? Articles { get; set; }
}

public class ArticleView
{
  public string Author { get; set; } = string.Empty;

  // [Required (ErrorMessage = "This field is required.")]
  // [StringLength(64)]
  public string? Title { get; set; }

  // [Required (ErrorMessage = "This field is required.")]
  public string? Text { get; set; }
  public ICollection<TagView> Tags { get; set; }
  public DateTime Published { get; init; }
  public DateTime Edited { get; set; }
}