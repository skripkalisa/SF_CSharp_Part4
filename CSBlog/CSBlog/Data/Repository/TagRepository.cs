using CSBlog.Core.Repository;
using CSBlog.Models.Blog;

namespace CSBlog.Data.Repository;

public class TagRepository : IRepository<Tag>
{
  private readonly ApplicationDbContext _context;

  public TagRepository(ApplicationDbContext context)
  {
    _context = context;
  }


  public ICollection<Tag> GetAll()
  {
    var tags = _context.Tags.ToList();
    return tags;
  }

  public Tag GetById(string? id)
  {
    var defaultTag = new Tag
    {
      Id = Guid.NewGuid().ToString(),
      TagName = "Not Found"
    };
    return _context.Tags.FirstOrDefault(t => t.Id.Equals(id)) ?? defaultTag;
  }

  public async Task Create(Tag item)
  {
    await _context.Tags.AddAsync(item);
    await _context.SaveChangesAsync();
    Console.WriteLine($"Task Create: {item}");
  }

  public async Task Update(Tag item)
  {
    var tag = GetById(item.Id);
    tag.TagName = item.TagName;
    _context.Tags.Update(tag);
    await _context.SaveChangesAsync();
  }

  public async Task Delete(Tag item)
  {
    var tag = GetById(item.Id);
    _context.Tags.Remove(tag);
    await _context.SaveChangesAsync();
  }
}