namespace PatternsLabs.ActiveRecord;

public class UserService
{
    public UserService() { }

    public User? GetUser(Guid id)
    {
        return User.Get(id);
    }

    public void SaveUser(User user)
    {
        user.Save();
    }

    public void BlockedUser(Guid id)
    {
        var user = GetUser(id);
        if (user!.IsBlocked) throw new Exception("Usuario ja bloqueado");

        user!.IsBlocked = true;
        user.Update();
    }
}