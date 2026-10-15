using E_Commerce_WebAPI.Models;

namespace E_Commerce_WebAPI.Repos.Interfaces
{
    public interface IProductRepo:IGenericRepo<Product>
    {
        Task<ICollection<Product>> GetProductsPagintaion(int? CategoryId
            , int PageNumber, int PageSize);

        Task<Product> MostExpensive(int CategoryId);

        Task<ICollection<Product>> SearchByName(string Name);
    }
}
