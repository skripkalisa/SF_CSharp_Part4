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

  public Task<Article[]> GetAllArticles()
  {
    throw new NotImplementedException();
  }

  public Task<Article[]> GetArticlesByAuthor(Guid userId)
  {
    throw new NotImplementedException();
  }

  public Task DeleteArticle(Guid articleId)
  {
    throw new NotImplementedException();
  }

  public Task AddComment(Comment comment)
  {
    throw new NotImplementedException();
  }

  public Task EditComment(Guid commentId)
  {
    throw new NotImplementedException();
  }

  public Task GetCommentById(Guid commentId)
  {
    throw new NotImplementedException();
  }

  public Task<Comment[]> GetAllComments()
  {
    throw new NotImplementedException();
  }

  public Task DeleteComment(Guid commentId)
  {
    throw new NotImplementedException();
  }

  public Task AddTag(Tag tag)
  {
    throw new NotImplementedException();
  }

  public Task EditTag(Guid tagId)
  {
    throw new NotImplementedException();
  }

  public Task GetTagById(Guid tagId)
  {
    throw new NotImplementedException();
  }

  public Task<Tag[]> GetAllTags()
  {
    throw new NotImplementedException();
  }

  public Task DeleteTag(Guid tagId)
  {
    throw new NotImplementedException();
  }
}