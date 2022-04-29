using CSBlog.Models.Blog;

namespace CSBlog.Models.Repository;

public class BlogRepository : IBlogRepository
{
  public Task AddArticle(Article article)
  {
    throw new NotImplementedException();
  }

  public Task EditArticle(Guid articleId)
  {
    throw new NotImplementedException();
  }

  public Task<Article[]> GetArticles()
  {
    throw new NotImplementedException();
  }

  public Task DeleteArticle(Guid articleId)
  {
    throw new NotImplementedException();
  }
}