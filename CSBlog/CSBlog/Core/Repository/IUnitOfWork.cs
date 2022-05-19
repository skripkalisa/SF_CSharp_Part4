namespace CSBlog.Core.Repository;

public interface IUnitOfWork
{
  IUserRepository User { get; }
  
  IRoleRepository Role { get; }
}