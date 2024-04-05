namespace PatternsLabs.Repository;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsAdmin { get; private set; }
    public bool IsBlocked { get; private set; }

    private User() { }

    public static User Create(string? name, string? email, string? pass, bool isAdmin = false)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            Password = pass,
            IsAdmin = isAdmin,
            IsBlocked = false
        };
    }

    public static User Load(User builder)
    {
        return new User
        {
            Id = builder.Id,
            Name = builder.Name,
            Email = builder.Email,
            Password = builder.Password,
            IsAdmin = builder.IsAdmin,
            IsBlocked = builder.IsBlocked
        };
    }

    public void SetBlock() => IsBlocked = true;
    public void SetAdmin() => IsAdmin = true;
}