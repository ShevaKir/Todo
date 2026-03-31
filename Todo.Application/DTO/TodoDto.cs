using Todo.Domain.Enums;

namespace Todo.Application.DTO;

public class TodoDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TodoStatus Status { get; set; }
}