namespace E_Commerce_WebAPI.Repos.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task AddAsync(T item);
        void Upadate(T item);
        void Delete(T item);
    }
}
