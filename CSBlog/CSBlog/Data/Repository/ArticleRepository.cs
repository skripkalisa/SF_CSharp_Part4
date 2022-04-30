using CSBlog.Models.Blog;

namespace CSBlog.Data.Repository;

public class ArticleRepository: Repository<Article>
{
  public ArticleRepository(ApplicationDbContext db) : base(db)
  {
  }
}