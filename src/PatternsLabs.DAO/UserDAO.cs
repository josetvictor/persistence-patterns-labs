using Microsoft.EntityFrameworkCore;

namespace PatternsLabs.DAO;

public class UserDAO : IUserDAO
{

    private readonly AppDbContext _con;
    public UserDAO(AppDbContext context)
    {
        _con = context;
    }

    public async Task<object?> Get(Guid id)
    {
        return await _con.User.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<IEnumerable<object?>> GetAll()
    {
        return await _con.User.ToListAsync();
    }

    public async Task<object> Save(object user)
    {
        _con.Add(user);
        await _con.SaveChangesAsync();
        return user;
    }

    public async Task<object> Update(object user)
    {
        _con.Update(user);
        await _con.SaveChangesAsync();
        return user;
    }
}