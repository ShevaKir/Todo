
namespace Todo.Domain.Interfaces;

public interface ITodoRepository
{
    Entities.TodoItem GetById(int id);
    IEnumerable<Entities.TodoItem> GetByUserId(int userId);
    void Add(Entities.TodoItem todo);
    void Update(Entities.TodoItem todo);
    void Delete(int id);
}