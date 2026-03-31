namespace Todo.Application.DTO;

public class CreateTodoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
}