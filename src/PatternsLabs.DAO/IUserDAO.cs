namespace PatternsLabs.DAO;

public interface IUserDAO
{
    Task<object> Save(object user);
    Task<object> Update(object user);
    Task<object?> Get(Guid id);
    Task<IEnumerable<object?>> GetAll();
}