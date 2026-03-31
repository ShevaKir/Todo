using Todo.Domain.Entities;
using Todo.Domain.Interfaces;

namespace Todo.Data.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }

    public TodoItem GetById(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo == null)
        {
            throw new Exception("Todo not found");
        }

        return todo;
    }

    public IEnumerable<TodoItem> GetByUserId(int userId)
    {
        return _context.Todos.Where(t => t.UserId == userId).ToList();
    }

    public void Add(TodoItem todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public void Update(TodoItem todo)
    {
        _context.Todos.Update(todo);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var todo = _context.Todos.Find(id);
        if (todo != null)
        {
            _context.Todos.Remove(todo);
            _context.SaveChanges();
        }
    }
}