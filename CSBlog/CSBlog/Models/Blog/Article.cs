namespace CSBlog.Models.Blog;

public class Article
{
  public Guid Id { get; set; } 
  public Guid UserId { get; set; } 
  public string Title { get; set; } = string.Empty;
  public string Text { get; set; } = string.Empty;
  public List<Tag> Tags { get; set; } = null!;
  public List<Comment> Comments { get; set; } = null!;
  public DateTime Published { get; set; }
  public DateTime Edited { get; set; }
}