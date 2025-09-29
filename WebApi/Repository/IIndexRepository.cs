using WebApi.Models;

namespace WebApi.Repository
{
    public interface IIndexRepository<T>
    {
        public Task<IEnumerable<T>?> GetAllAsync();
        public Task<T?> GetByIdAsync(int id);
        public Task<T> AddAsync(T entity);
        public Task<bool>  UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);



    }
}
