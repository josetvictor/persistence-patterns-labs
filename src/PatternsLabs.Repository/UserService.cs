using System.Data;

namespace PatternsLabs.Repository;

public class UserService
{
    private readonly IUserRepository _userRepository;
    public UserService(AppDbContext context)
    {
        _userRepository = new UserRepository(context);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetUserAsync(Guid id)
    {
        return await _userRepository.GetAsync(id);
    }

    public async Task<User> SaveUser(UserDTO userDto)
    {
        var user = User.Create(userDto.Name, userDto.Email, userDto.PassWord);
        return await _userRepository.SaveAsync(user);
    }

    public async Task<User> BlockedUser(Guid id)
    {
        var user = GetUserAsync(id);
        user.Result!.SetBlock();
        return await _userRepository.UpdateAsync(user.Result);
    }

    public Task<User> SetAdmin(Guid id)
    {
        var user = GetUserAsync(id);
        user.Result!.SetAdmin();
        return _userRepository.UpdateAsync(user.Result);
    }
}