
namespace CalmEd.Services;

public class AuthState
{
    private readonly List<AppUser> _users = new();

    public AppUser? CurrentUser { get; private set; }

    public bool Register(
        string username,
        string email,
        string password,
        out string message)
    {
        if (_users.Any(u =>
            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
        {
            message = "An account with this email already exists.";
            return false;
        }

        var user = new AppUser(username, email, password);
        _users.Add(user);

        message = "Account created successfully!";
        return true;
    }

    public bool Login(
        string email,
        string password,
        out string message)
    {
        var user = _users.FirstOrDefault(u =>
            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
            && u.Password == password);

        if (user == null)
        {
            message = "Invalid email or password.";
            return false;
        }

        CurrentUser = user;
        message = "Login successful!";
        return true;
    }

    public void Logout()
    {
        CurrentUser = null;
    }
}

public record AppUser(
    string Username,
    string Email,
    string Password);