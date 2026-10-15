using E_Commerce_WebAPI.Data;
using E_Commerce_WebAPI.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebAPI.Repos.Implementations
{
    public class GenericRepo<T>:IGenericRepo<T> where T : class
    {
        private readonly AppDbContext context;
        public DbSet<T> db;
        public GenericRepo(AppDbContext context)
        {
            this.context = context;
            db=context.Set<T>();
        }

        public async Task AddAsync(T item)
        {
            await db.AddAsync(item);
        }

        public void Delete(T item)
        {
            db.Remove(item);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
          return  await db.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
           return await db.FindAsync(id);
        }

        public void Upadate(T item)
        {
            db.Update(item);
        }
    }
}
