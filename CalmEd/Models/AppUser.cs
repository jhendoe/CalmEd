
namespace CalmEd.Models;

public class AppUser
{
    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    // Prototype only. Do not store real passwords as plain text.
    public string Password { get; set; } = string.Empty;

    public AppUser()
    {
    }

    public AppUser(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password;
    }
}