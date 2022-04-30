using CSBlog.Models.Blog;

namespace CSBlog.Data.Repository;

public class TagRepository : Repository<Tag>
{
  public TagRepository(ApplicationDbContext db) : base(db)
  {
  }
}