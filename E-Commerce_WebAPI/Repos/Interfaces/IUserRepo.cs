using E_Commerce_WebAPI.Models;

namespace E_Commerce_WebAPI.Repos.Interfaces
{
    public interface IUserRepo:IGenericRepo<User>
    {
        Task<User> GetByEmail(string email);
    }
}
