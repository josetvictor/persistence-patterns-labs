namespace PatternsLabs.DAO;

public class UserService
{
    private readonly IUserDAO _userDAO;
    public UserService(AppDbContext con)
    {
        _userDAO = new UserDAO(con);
    }

    public Task<IEnumerable<object?>> GetAll()
    {
        return _userDAO.GetAll();
    }

    public Task<object?> GetUser(Guid id)
    {
        return _userDAO.Get(id);
    }

    public Task<object> SaveUser(User User)
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

    public Task<object> BlockedUser(Guid id)
    {
        User user = (User)GetUser(id).Result ?? throw new Exception("Usuario inexistente");
        if (user!.IsBlocked) throw new Exception("Usuario ja bloqueado");

        user!.IsBlocked = true;
        return _userDAO.Update(user);
    }

    public Task<object> SetAdmin(Guid id)
    {
        var user = (User)GetUser(id).Result ?? throw new Exception("Usuario inexistente");
        if (user!.IsAdmin) throw new Exception("Usuario ja é um administrador");

        user!.IsAdmin = true;
        return _userDAO.Update(user);
    }
}