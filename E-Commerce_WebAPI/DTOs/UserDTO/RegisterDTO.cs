using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.DTOs.UserDTO
{
    public class RegisterDTO
    {
        [Required]
        [StringLength(100), MinLength(3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
