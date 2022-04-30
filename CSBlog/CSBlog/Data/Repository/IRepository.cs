namespace CSBlog.Data.Repository;

public interface IRepository<T> where T : class
{
  IEnumerable<T> GetAll();
  // T Get(int id);
  Task Create(T item);
  Task Update(T item);
  Task Delete(T item);
}