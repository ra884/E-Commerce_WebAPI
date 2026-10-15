using E_Commerce_WebAPI.Models;

namespace E_Commerce_WebAPI.Repos.Interfaces
{
    public interface IOrderRepo:IGenericRepo<Order>
    {
        Task<decimal> TotalRevenue();
    }
}
