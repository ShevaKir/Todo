using Todo.Application.DTO;
using Todo.Domain.Enums;
using Todo.Domain.Interfaces;

namespace Todo.Application.Services;

public class TodoService
{
    private ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public void CreateTodo(CreateTodoDto todoDto)
    {
        var todo = new Domain.Entities.Todo
        {
            Title = todoDto.Title,
            Description = todoDto.Description,
            UserId = todoDto.UserId,
            Status = TodoStatus.New
        };

        _todoRepository.Add(todo);
    }

    public IEnumerable<TodoDto> GetByUserId(int userId)
    {
        var todos = _todoRepository.GetByUserId(userId);
        return todos.Select(t => new TodoDto()
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            Status = t.Status
        });
    }

    public void StartTodo(int id)
    {
        var todo = _todoRepository.GetById(id);
        todo.Status = TodoStatus.InProgress;
        _todoRepository.Update(todo);
    }

    public void CompleteTodo(int id)
    {
        var todo = _todoRepository.GetById(id);
        todo.Status = TodoStatus.Completed;
        _todoRepository.Update(todo);
    }
}