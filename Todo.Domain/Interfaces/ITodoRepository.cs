
namespace Todo.Domain.Interfaces;

public interface ITodoRepository
{
    Entities.Todo GetById(int id);
    IEnumerable<Entities.Todo> GetByUserId(int userId);
    void Add(Entities.Todo todo);
    void Update(Entities.Todo todo);
    void Delete(int id);
}