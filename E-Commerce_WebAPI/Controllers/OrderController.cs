using System.Data;
using E_Commerce_WebAPI.DTOs.OrderDTO;
using E_Commerce_WebAPI.DTOs.ProductDTO;
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
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

      

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await unitOfWork.orderRepo.GetAsync(id);
            if (order == null)
            {
                return NotFound("order not found.");
            }
            var orderDTO = new GetOrderDTO
            {
                OrderDate = order.OrderDate,
                Status = order.Status,
            };
            return Ok(orderDTO);
        }

 

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO orderDTO)
        {
            if (orderDTO == null)
            {
                return BadRequest("order data is null");
            }
            var order = new Order
            {
                OrderDate= orderDTO.OrderDate,
                TotalAmount= orderDTO.TotalAmount,
                Status = orderDTO.Status,
                CustomerId= orderDTO.CustomerId,
            };  
            await unitOfWork.orderRepo.AddAsync(order);
            await unitOfWork.SaveAsync();
            return Created();

        }

   

        [HttpPatch]
        public async Task<IActionResult> UpdateStatus(int id, UpdateOrderStatusDTO orderStatusDTO  )
        {
            if (orderStatusDTO == null)
            {
                return BadRequest("data is null");
            }
            var order = await unitOfWork.orderRepo.GetAsync(id);
            order.Status = orderStatusDTO.Status;
            unitOfWork.orderRepo.Upadate(order);
            await unitOfWork.SaveAsync();
            return Ok();
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenue()
        {
            var revenue = await unitOfWork.orderRepo.TotalRevenue();
            return Ok(revenue);
        }
    }
}
