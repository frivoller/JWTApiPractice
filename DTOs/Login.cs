using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace JWTApiPractice.DTOs
{
    public sealed record Login
    {
        [Required]
        public string Email { get; init; } = string.Empty;
        [Required]
        public string Password { get; init; } = string.Empty;
    }
}