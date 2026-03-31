using Todo.Domain.Entities;

namespace Todo.Domain.Interfaces;

public interface IUserRepository
{
    User GetById(int id);
    IEnumerable<User> GetAll();
    void Add(User user);
    void Update(User user);
    void Delete(int id);
}