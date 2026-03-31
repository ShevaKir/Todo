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

        foreach (var todoDto in todoService.GetByUserId(id))
        {
            Console.WriteLine(todoDto.Title + " " + todoDto.Status);
        }

        todoService.CompleteTodo(2);

        foreach (var todoDto in todoService.GetByUserId(id))
        {
            Console.WriteLine(todoDto.Title + " " + todoDto.Status);
        }
    }
}