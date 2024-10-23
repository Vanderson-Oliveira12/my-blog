using MyBlog.Models;
using MyBlog.UoW;

namespace MyBlog.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        IUnitOfWork UnitOfWork { get; }
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        void Create(T model);
        void Update(T model);
        void Delete(T model);
    }
}
