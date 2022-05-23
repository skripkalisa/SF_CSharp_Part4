namespace CSBlog.Core.Repository;

public interface IRepository<T> where T : class
{
  //Retrieves list of items in table
  // IQueryable<T> List();
  // IQueryable<T> List(params string[] includes);
  //
  // //Creates from detached item
  // void Create(T item);
  // void Delete(string id);
  // T Get(string id);
  // T Get(string id, params string[] includes);
  // void SaveChanges();

  ICollection<T> GetAll();
  T GetById(string? id);
  Task Create(T item);
  Task Update(T item);
  Task Delete(T item);
}