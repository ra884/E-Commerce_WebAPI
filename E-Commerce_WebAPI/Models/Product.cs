using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100),MinLength(2)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        [Required]
        [Range(0.01,1000000)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 1000000)]
        public int StockQuantity { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<OrderItem> Items { get; set; }   
    }
}
