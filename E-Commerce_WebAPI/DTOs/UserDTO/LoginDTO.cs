using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.DTOs.UserDTO
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
