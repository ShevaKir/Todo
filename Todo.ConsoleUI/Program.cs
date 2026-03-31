using Microsoft.EntityFrameworkCore;
using Todo.Application.DTO;
using Todo.Application.Services;
using Todo.Data;
using Todo.Data.Repositories;
using Todo.Domain.Entities;

namespace Todo.ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        var connectionString = DbConstants.ConnectionString;
        var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
        optionsBuilder.UseNpgsql(connectionString);
        using var context = new TodoDbContext(optionsBuilder.Options);

        var userRepository = new UserRepository(context);
        var todoRepository = new TodoRepository(context);

        var userService = new UserService(userRepository);
        var todoService = new TodoService(todoRepository);


        var id = userService.GetById(1).Id;

        todoService.CreateTodo(new CreateTodoDto()
        {
            Title = "Task 1",
            Description = "Description 1",
            UserId = id
        });

        todoService.CreateTodo(new CreateTodoDto()
        {
            Title = "Task 2",
            Description = "Description 2",
            UserId = id
        });


        foreach (var todoDto in todoService.GetByUserId(id))
        {
            Console.WriteLine(todoDto.Title);
        }
    }
}