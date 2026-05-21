using Backend.Domain.Common;

namespace Backend.Domain.Entities;

public class User : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
    public string? PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Role { get; set; }
    public string? ProfileImageUrl { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public DateTime? PasswordChangedAt { get; set; }

    public string FullName => string.Join(" ", new[] { FirstName, LastName }
        .Where(s => !string.IsNullOrWhiteSpace(s)));
}
