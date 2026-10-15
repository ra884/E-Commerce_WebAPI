using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.DTOs.OrderDTO
{
    public class GetOrderDTO
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
