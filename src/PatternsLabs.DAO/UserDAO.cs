using Microsoft.EntityFrameworkCore;

namespace PatternsLabs.DAO;

public class UserDAO : IUserDAO
{

    private readonly AppDbContext _con;
    public UserDAO(AppDbContext context)
    {
        _con = context;
    }

    public async Task<User?> Get(Guid id)
    {
        return await _con.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> Save(User user)
    {
        _con.Add(user);
        await _con.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(User user)
    {
        _con.Update(user);
        await _con.SaveChangesAsync();
        return user;
    }
}