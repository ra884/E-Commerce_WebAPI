using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public User Customer { get; set; }
        public int CustomerId { get; set; }
        public ICollection<OrderItem> Items { get; set; }
    }
}
