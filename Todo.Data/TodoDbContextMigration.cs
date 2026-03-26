using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Todo.Data;

public class TodoDbContextMigration : IDesignTimeDbContextFactory<TodoDbContext>
{
    public TodoDbContext CreateDbContext(string[] args)
    {
        var connectionString = "Host=localhost;Port=5432;Database=todo-app;Username=postgres;Password=postgres;";

        var optionsBuilder = new DbContextOptionsBuilder<TodoDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new TodoDbContext(optionsBuilder.Options);
    }
}