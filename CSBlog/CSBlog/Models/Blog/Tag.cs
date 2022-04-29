namespace CSBlog.Models.Blog;

public class Tag
{
  // internal List<string> Tags { get; set; }
  public Guid Id { get; set; }
  internal string TagName { get; set; }= string.Empty;
}