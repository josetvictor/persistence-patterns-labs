using Microsoft.EntityFrameworkCore;

namespace PatternsLabs.ActiveRecord;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsBlocked { get; set; }

    private readonly AppDbContext _context;

    public User(AppDbContext context, string name, string email, string password)
    {
        _context = context;

        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        IsAdmin = false;
        IsBlocked = false;
    }

    public async Task<User> Save()
    {
        _context.Add(this);
        await _context.SaveChangesAsync();
        return this;
    }

    public async Task<User> Update()
    {
        _context.Update(this);
        await _context.SaveChangesAsync();
        return this;
    }

    public async Task<User?> Get(Guid id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
}