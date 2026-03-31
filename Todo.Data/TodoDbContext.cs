using Microsoft.EntityFrameworkCore;
using Todo.Data.Configurations;
using Todo.Domain.Entities;

namespace Todo.Data;

public class TodoDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TodoItem> Todos { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}