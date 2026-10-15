using System.Net.Http.Headers;
using E_Commerce_WebAPI.Data;
using E_Commerce_WebAPI.Models;
using E_Commerce_WebAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebAPI.Repos.Implementations
{
    public class ProductRepo:GenericRepo<Product>,IProductRepo
    {
        private readonly AppDbContext context;
        public ProductRepo(AppDbContext context):base(context) 
        {
            this.context = context;
        }

        public async Task<ICollection<Product>> GetProductsPagintaion(int? CategoryId, int PageNumber, int PageSize)
        {
            IQueryable<Product> products = context.Products;
            if (CategoryId != null)
            {
                products =  products.Where(p => p.CategoryId == CategoryId);
            }
            products = products.Skip((PageNumber - 1) * PageSize)
                .Take(PageSize).OrderBy(p=>p.StockQuantity);
            return await products.ToListAsync();
          
        }

        public async Task<Product> MostExpensive(int CategoryId)
        {
            var product =await context.Products.Where(p => p.CategoryId == CategoryId)
                .OrderByDescending(p => p.Price)
                .Skip(1).FirstOrDefaultAsync();
            return product;
            
        }

        public async Task<ICollection<Product>> SearchByName(string Name)
        {
           var products= context.Products.Where(p => p.Name == Name);
            return await products.ToListAsync();
        }

    }
}
