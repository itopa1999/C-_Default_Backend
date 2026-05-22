using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs;

public class AuthResponseDto
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }
}

public class LoginUserDto
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}