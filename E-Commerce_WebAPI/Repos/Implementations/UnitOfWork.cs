using E_Commerce_WebAPI.Data;
using E_Commerce_WebAPI.Models;
using E_Commerce_WebAPI.Repos.Interfaces;

namespace E_Commerce_WebAPI.Repos.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IUserRepo userRepo { get; }
        public IGenericRepo<Category> categoryRepo { get; }
        public IProductRepo productRepo { get; }
        public IOrderRepo orderRepo { get; }


        public UnitOfWork(AppDbContext context,
            IUserRepo userRepo, IGenericRepo<Category> categoryRepo
            , IProductRepo productRepo, IOrderRepo orderRepo)
        {
            this.context = context;
            this.userRepo = userRepo;
            this.categoryRepo = categoryRepo;
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
