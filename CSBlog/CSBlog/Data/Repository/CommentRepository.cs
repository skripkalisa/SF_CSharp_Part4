using CSBlog.Core.Repository;
using CSBlog.Models.Blog;

namespace CSBlog.Data.Repository;

public class CommentRepository : IRepository<Comment>
{
  private readonly ApplicationDbContext _context;

  public CommentRepository(ApplicationDbContext context)
  {
    _context = context;
  }

  public ICollection<Comment> GetAll()
  {
    var comments = _context.Comments.ToList();
    return comments;
  }

  public Comment GetById(string? id)
  {
    var comment = _context.Comments.FirstOrDefault(t => t.Id == id);
    if (comment == null) return new Comment();
    return comment;
  }

  public async Task Create(Comment item)
  {
    await _context.Comments.AddAsync(item);
    await _context.SaveChangesAsync();
  }

  public async Task Update(Comment item)
  {
    var comment = GetById(item.Id);
    comment.Text = item.Text;
    comment.Changed = DateTime.Now;


    _context.Comments.Update(comment);
    await _context.SaveChangesAsync();
  }

  public async Task Delete(Comment item)
  {
    var comment = GetById(item.Id);
    _context.Comments.Remove(comment);
    await _context.SaveChangesAsync();
  }
}