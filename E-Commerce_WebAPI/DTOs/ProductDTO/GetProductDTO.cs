using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.DTOs.ProductDTO
{
    public class GetProductDTO
    {
        [Required]
        [StringLength(100), MinLength(2)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        [Range(0.01, 1000000)]
        public decimal Price { get; set; }
    }
}
