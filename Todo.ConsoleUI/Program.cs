using Microsoft.EntityFrameworkCore;
using Todo.Data;
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

        var user1 = new User() { Username = "Kyrylo", Email = "kyrylo@gmail.com" };
        var user2 = new User() { Username = "Stanislav", Email = "stanislav@gmail.com" };

        context.Users.AddRange(user1, user2);
        context.SaveChanges();
        context.ChangeTracker.Clear();

        foreach (var user in context.Users)
        {
            Console.WriteLine(user.Username);
        }
    }
}