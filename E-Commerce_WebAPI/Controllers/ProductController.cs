using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using E_Commerce_WebAPI.DTOs.CategoryDTO;
using E_Commerce_WebAPI.DTOs.ProductDTO;
using E_Commerce_WebAPI.Models;
using E_Commerce_WebAPI.Repos.Implementations;
using E_Commerce_WebAPI.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int CategoryId, int PageNumber, int PageSize)
        {
            var products = await unitOfWork.productRepo.GetProductsPagintaion(CategoryId, PageNumber, PageSize);
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            var productsDTO = products.Select(c => new GetProductDTO
            {
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
            });
            return Ok(productsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await unitOfWork.productRepo.GetAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            var productDTO = new GetProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
            return Ok(productDTO);
        }

        [HttpGet("second-most-expensive")]
        public async Task<IActionResult> GeSecond(int Categoryid)
        {
            var product = await unitOfWork.productRepo.MostExpensive(Categoryid);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            var productDTO = new GetProductDTO
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };
            return Ok(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("product data is null");
            }
            var product = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Price = productDTO.Price,
                StockQuantity = productDTO.StockQuantity,
                CategoryId = productDTO.CategoryId
            };
            await unitOfWork.productRepo.AddAsync(product);
            await unitOfWork.SaveAsync();
            return Created();

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("product data is null");
            }
            var product = await unitOfWork.productRepo.GetAsync(id);
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.StockQuantity = productDTO.StockQuantity;
            product.CategoryId = productDTO.CategoryId;
            unitOfWork.productRepo.Upadate(product);
            await unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateStock(int id, UpdateStockDTO stockDTO)
        {
            if (stockDTO == null)
            {
                return BadRequest("data is null");
            }
            var product = await unitOfWork.productRepo.GetAsync(id);
            product.StockQuantity = stockDTO.StockQuantity;
            unitOfWork.productRepo.Upadate(product);
            await unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpGet("searh")]
        public async Task<IActionResult> SearchByName(string name)
        {
            var products = await unitOfWork.productRepo.SearchByName(name);
            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            var productsDTO = products.Select(c => new GetProductDTO
            {
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
            });
            return Ok(productsDTO);
        }
    }
}
