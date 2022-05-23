using CSBlog.Models.Blog;

namespace CSBlog.Core.Repository;

public interface IBlogRepository
{
  /// <summary>
  /// Article related methods
  /// </summary>
  /// <param name="article"></param>
  /// <returns></returns>
  // Task AddArticle(Article article);
  //
  // Task EditArticle(Article article);
  // List<Article> GetAllArticles();
  // List<Article> GetArticlesByAuthor(string userId);
  // Task DeleteArticle(string articleId);

  /// <summary>
  /// Commentary related methods
  /// </summary>
  /// <param name="comment"></param>
  /// <returns></returns>
  // Task AddComment(Comment comment);
  //
  // Task EditComment(Comment comment);
  // Comment GetCommentById(string commentId);
  // List<Comment> GetAllComments();
  // Task DeleteComment(string commentId);

  /// <summary>
  /// Tag related methods
  /// </summary>
  /// <param name="tag"></param>
  /// <returns></returns>
  Task AddTag(Tag tag);

  Task EditTag(Tag tag);
  Tag GetTagById(string tagId);
  ICollection<Tag> GetAllTags();
  Task DeleteTag(string tagId);
}