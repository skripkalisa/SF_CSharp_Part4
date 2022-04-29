using CSBlog.Models.Blog;

namespace CSBlog.Models.Repository;

public interface IBlogRepository
{
  /// <summary>
  /// Article related methods
  /// </summary>
  /// <param name="article"></param>
  /// <returns></returns>
  Task AddArticle(Article article);
  Task EditArticle(Guid articleId);
  Task<Article[]> GetAllArticles();
  Task<Article[]> GetArticlesByAuthor(Guid userId);
  Task DeleteArticle(Guid articleId);  
  
  /// <summary>
  /// Commentary related methods
  /// </summary>
  /// <param name="comment"></param>
  /// <returns></returns>
  Task AddComment(Comment comment);
  Task EditComment(Guid commentId);
  Task GetCommentById(Guid commentId);
  Task<Comment[]> GetAllComments();
  Task DeleteComment(Guid commentId);  

  /// <summary>
  /// Tag related methods
  /// </summary>
  /// <param name="tag"></param>
  /// <returns></returns>
  Task AddTag(Tag tag);
  Task EditTag(Guid tagId);
  Task GetTagById(Guid tagId);
  Task<Tag[]> GetAllTags();
  Task DeleteTag(Guid tagId);
  
  
  
}