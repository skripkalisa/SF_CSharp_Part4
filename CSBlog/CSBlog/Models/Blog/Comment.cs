namespace CSBlog.Models.Blog;

public class Comment
{
  public Guid Id { get; set; }
  public Guid ArticleId { get; set; }
  public Guid UserId { get; set; }
  public string Text { get; set; } = string.Empty;
  public DateTime Added { get; set; }
  public DateTime Changed { get; set; }
}