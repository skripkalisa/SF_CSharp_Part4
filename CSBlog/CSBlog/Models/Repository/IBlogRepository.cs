using CSBlog.Models.Blog;

namespace CSBlog.Models.Repository;

public interface IBlogRepository
{
  Task AddArticle(Article article);
  Task EditArticle(Guid articleId);
  Task<Article[]> GetArticles();
  Task DeleteArticle(Guid articleId);
}