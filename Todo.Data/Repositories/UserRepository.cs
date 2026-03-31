using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;

namespace Todo.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TodoDbContext _context;

    public UserRepository(TodoDbContext context)
    {
        _context = context;
    }

    public User GetById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users.Include(u => u.Todos).ToList();
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}