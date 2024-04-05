namespace PatternsLabs.DAO;

public interface IUserDAO
{
    Task<User> Save(User user);
    Task<User> Update(User user);
    Task<User?> Get(Guid id);
}