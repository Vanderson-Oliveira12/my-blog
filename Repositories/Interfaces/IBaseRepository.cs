using MyBlog.Models;

namespace MyBlog.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
        Task DeleteAsync(Guid id);
    }
}
