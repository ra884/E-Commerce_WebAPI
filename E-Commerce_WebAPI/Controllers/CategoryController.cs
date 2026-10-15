using E_Commerce_WebAPI.DTOs.CategoryDTO;
using E_Commerce_WebAPI.Models;
using E_Commerce_WebAPI.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await unitOfWork.categoryRepo.GetAllAsync();
            if (categories == null || !categories.Any())
            {
                return NotFound("No categories found");
            }
            var categoriesDTO = categories.Select(c => new GetCategoryDTO
            {
                Name = c.Name,
                Description = c.Description,
            });
            return Ok(categoriesDTO);
        }
            [HttpPost]
            public async Task<IActionResult> CreateCategory(CreateCategoryDTO categoryDTO)
            { 
            if (categoryDTO == null)
            {
                return BadRequest("Category data is null");
            }
            var category = new Category
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
            };
            await unitOfWork.categoryRepo.AddAsync(category);
            await unitOfWork.SaveAsync();
            return Created();

        }
        
    } 
}
