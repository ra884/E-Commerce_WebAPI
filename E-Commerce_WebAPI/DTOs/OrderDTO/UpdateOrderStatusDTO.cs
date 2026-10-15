using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.DTOs.OrderDTO
{
    public class UpdateOrderStatusDTO
    {
        [Required]
        public string Status { get; set; }
    }
}
