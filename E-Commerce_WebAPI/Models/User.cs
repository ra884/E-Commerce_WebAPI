using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebAPI.Models
{
    [Index(nameof(Email),IsUnique =true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100),MinLength(3)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Role { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
