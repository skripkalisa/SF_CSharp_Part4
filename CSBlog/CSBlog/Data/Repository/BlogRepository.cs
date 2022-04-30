using CSBlog.Models.Blog;

namespace CSBlog.Data.Repository;

public class BlogRepository : IBlogRepository
{
  
   private readonly ApplicationDbContext _context;

   public BlogRepository(ApplicationDbContext context)
   {
     _context = context;
   }

   public async Task AddArticle(Article article)
   {
     await _context.AddAsync(article);
     await _context.SaveChangesAsync();
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