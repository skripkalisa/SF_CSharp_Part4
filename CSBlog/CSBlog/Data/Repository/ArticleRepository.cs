using CSBlog.Core.Repository;
using CSBlog.Models.Blog;

namespace CSBlog.Data.Repository;

public class ArticleRepository : IRepository<Article>
{
  private readonly ApplicationDbContext _context;

  public ArticleRepository(ApplicationDbContext context)
  {
    _context = context;
  }


  public ICollection<Article> GetAll()
  {
    var articles = _context.Articles.ToList();
    return articles;
  }

  public Article GetById(string? id)
  {
    var defaultArticle = new Article
    {
      Id = Guid.NewGuid().ToString(),
      Title = "Not Found"
    };

    return _context.Articles.FirstOrDefault(t => t.Id == id) ?? defaultArticle;
  }

  public async Task Create(Article item)
  {
    await _context.Articles.AddAsync(item);
    await _context.SaveChangesAsync();
    // Console.WriteLine($"Task Create: {item}");
  }

  public async Task Update(Article item)
  {
    var article = GetById(item.Id);
    article.Title = item.Title;
    article.Text = item.Text;
    article.Tags = item.Tags;
    article.Comments = item.Comments;
    article.Edited = DateTime.Now;

    _context.Articles.Update(article);
    await _context.SaveChangesAsync();
  }

  public async Task Delete(Article item)
  {
    var article = GetById(item.Id);
    _context.Articles.Remove(article);
    await _context.SaveChangesAsync();
  }
}