using System.ComponentModel.DataAnnotations;

namespace E_Commerce_WebAPI.DTOs.ProductDTO
{
    public class UpdateStockDTO
    {
        [Required]
        [Range(0, 1000000)]
        public int StockQuantity { get; set; }
    }
}
