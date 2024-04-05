using System.Data;

namespace PatternsLabs.DAO;

public class UserService
{
    private readonly IUserDAO _userDAO;
    public UserService(AppDbContext con)
    {
        _userDAO = new UserDAO(con);
    }

    public Task<User?> GetUser(Guid id)
    {
        return _userDAO.Get(id);
    }

    public Task<User> SaveUser(User User)
    {
        var user = new User
        {
            Id = new Guid(),
            Name = User.Name,
            Email = User.Email,
            Password = User.Password
        };
        return _userDAO.Save(user);
    }

    public Task<User> BlockedUser(Guid id)
    {
        var user = GetUser(id).Result;
        if (user!.IsBlocked) throw new Exception("Usuario ja bloqueado");

        user!.IsBlocked = true;
        return _userDAO.Update(user);
    }

    public Task<User> SetAdmin(Guid id)
    {
        var user = GetUser(id).Result;
        if (user!.IsAdmin) throw new Exception("Usuario ja é um administrador");

        user!.IsAdmin = true;
        return _userDAO.Update(user);
    }
}