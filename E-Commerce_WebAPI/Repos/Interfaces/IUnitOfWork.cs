using E_Commerce_WebAPI.Models;

namespace E_Commerce_WebAPI.Repos.Interfaces
{
    public interface IUnitOfWork
    {
        public IUserRepo userRepo { get; }
        public IGenericRepo<Category> categoryRepo { get; } 
        public IProductRepo productRepo { get; }
        public IOrderRepo orderRepo { get; }
        Task SaveAsync();
    }
}
