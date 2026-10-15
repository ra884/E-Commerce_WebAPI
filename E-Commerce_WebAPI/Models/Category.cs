using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebAPI.Models
{
    [Index(nameof(Name),IsUnique =true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100),MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        public ICollection<Product> Products { get; set; }  
    }
}
