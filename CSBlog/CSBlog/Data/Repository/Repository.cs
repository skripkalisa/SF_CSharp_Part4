using Microsoft.EntityFrameworkCore;

namespace CSBlog.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
  private readonly DbContext _db;

  public DbSet<T> Set { get; private set; }

  protected Repository(ApplicationDbContext db)
  {
    _db = db;
    var set = _db.Set<T>();
    set.Load();

    Set = set;
  }

  public async Task Create(T item)
  {
    Set.Add(item);
    await _db.SaveChangesAsync();
  }

  public async Task Delete(T item)
  {
    Set.Remove(item);
    await _db.SaveChangesAsync();
  }

  // public T Get(int id)
  // {
  //   return Set.Find(id);// ?? throw new InvalidOperationException();
  // }

  public IEnumerable<T> GetAll()
  {
    return Set;
  }

  public async Task Update(T item)
  {
    Set.Update(item);
    await _db.SaveChangesAsync();
  }
}