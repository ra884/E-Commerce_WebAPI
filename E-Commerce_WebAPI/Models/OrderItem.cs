using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1,1000)]
        public int Quantity { get; set; }
        [Required]
        [Range(0.01, 1000000)]
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
