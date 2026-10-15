using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.DTOs.CategoryDTO
{
    public class CreateCategoryDTO
    {
        [Required]
        [StringLength(100), MinLength(2)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
