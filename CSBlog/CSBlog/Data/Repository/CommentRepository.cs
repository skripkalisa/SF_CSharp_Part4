using CSBlog.Models.Blog;

namespace CSBlog.Data.Repository;

public class CommentRepository: Repository<Comment>
{
  public CommentRepository(ApplicationDbContext db) : base(db)
  {
  }
}