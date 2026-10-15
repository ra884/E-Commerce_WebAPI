using E_Commerce_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.DTOs.OrderDTO
{
    public class CreateOrderDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
    }
}
