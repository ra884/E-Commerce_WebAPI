using E_Commerce_WebAPI.Data;
using E_Commerce_WebAPI.Models;
using E_Commerce_WebAPI.Repos.Interfaces;

namespace E_Commerce_WebAPI.Repos.Implementations
{
    public class OrderRepo:GenericRepo<Order>,IOrderRepo
    {
        private AppDbContext Context;
        public OrderRepo(AppDbContext context):base(context) 
        {
            Context = context;
        }

        public async Task<decimal> TotalRevenue()
        {
            var revenue = Context.Orders.Where(o => o.Status == "Completed")
                .Sum(o => o.TotalAmount);
            return revenue;
        }
    }
}
