namespace PatternsLabs.Repository;

public interface IUserRepository
{
    Task<User> SaveAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(User user);
    Task<User?> GetAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
}