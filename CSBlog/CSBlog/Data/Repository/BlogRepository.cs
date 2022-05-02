using CSBlog.Models.Blog;
using Microsoft.EntityFrameworkCore;

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
    article.Published = DateTime.Now;
    await _context.AddAsync(article);
    await _context.SaveChangesAsync();
  }

  public async Task EditArticle(Article article)
  {
    var art = await _context.Articles.FindAsync(article.Id);

    if (art != null)
    {
      art.Author = article.Author;

      art.Title = article.Title;

      art.Text = article.Text;

      foreach (var tag in article.Tags)
      {
        if (!art.Tags.Contains(tag))
          art.Tags.Add(tag);
      }

      art.Edited = DateTime.Now;
    }

    await _context.SaveChangesAsync();
  }

  public async Task<Article[]> GetAllArticles()
  {
    return await _context.Articles.ToArrayAsync();
  }

  public async Task<Article[]> GetArticlesByAuthor(Guid userId)
  {
    return await _context.Articles.Where(art => art.UserId == userId).ToArrayAsync();
  }

  public async Task DeleteArticle(Guid articleId)
  {
    var article = _context.Articles.Where(art => art.Id == articleId);
    _context.Remove(article);
    await _context.SaveChangesAsync();
  }

  public async Task AddComment(Comment comment)
  {
    comment.Added = DateTime.Now;
    await _context.AddAsync(comment);
    await _context.SaveChangesAsync();
  }

  public async Task EditComment(Comment comment)
  {
    var com = await _context.Comments.FindAsync(comment.Id);

    if (com != null)
    {
      com.Text = comment.Text;
      com.Changed = DateTime.Now;
    }

    await _context.SaveChangesAsync();
  }

  public Comment GetCommentById(Guid commentId)
  {
    var comment = _context.Comments.Find(commentId);
    if (comment != null) return comment;

    throw new InvalidOperationException();
  }

  public async Task<Comment[]> GetAllComments()
  {
    return await _context.Comments.ToArrayAsync();
  }

  public async Task DeleteComment(Guid commentId)
  {
    var comment = _context.Comments.Where(comm => comm.Id == commentId);
    _context.Remove(comment);
    await _context.SaveChangesAsync();
  }

  public async Task AddTag(Tag tag)
  {
    await _context.AddAsync(tag);
    await _context.SaveChangesAsync();
  }


  public async Task EditTag(Tag tag)
  {
    var tg = await _context.Tags.FindAsync(tag.Id);

    if (tg != null) tg.TagName = tag.TagName;

    await _context.SaveChangesAsync();
  }

  public Tag GetTagById(Guid tagId)
  {
    var tag = _context.Tags.Find(tagId);
    if (tag != null) return tag;

    throw new InvalidOperationException();
  }

  public async Task<Tag[]> GetAllTags()
  {
    return await _context.Tags.ToArrayAsync();
  }

  public async Task DeleteTag(Guid tagId)
  {
    var tag = _context.Tags.Where(tag => tag.Id == tagId);
    _context.Remove(tag);
    await _context.SaveChangesAsync();
  }
}