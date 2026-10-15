using E_Commerce_WebAPI.Data;
using E_Commerce_WebAPI.Models;
using E_Commerce_WebAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebAPI.Repos.Implementations
{
    public class UserRepo:GenericRepo<User>,IUserRepo
    {
        private readonly AppDbContext context;
        public UserRepo(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
