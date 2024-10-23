using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Repositories;
using MyBlog.DTOs;
using MyBlog.ViewModels;

namespace MyBlog.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();   
        Task<CategoryDTO> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(CreateCategoryViewModel model);
        Task<Guid> UpdateAsync(Guid id, UpdateCategoryViewModel model);
        Task DeleteAsync(Guid id);
    }
}
