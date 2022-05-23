using CSBlog.Models.Blog;

namespace CSBlog.Core.ViewModels.Blog;

public class TagArticleViewModel
{
  public string? TagName { get; set; }
  public string? TagId { get; set; }
  public Tag? Tag { get; set; }

}