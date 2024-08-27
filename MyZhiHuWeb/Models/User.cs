namespace MyZhiHuWeb.Models;

public class User
{
    public class Register
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public UserRole? Role { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}

public enum UserRole
{
    Admin = 1,
    User = 2,
}
