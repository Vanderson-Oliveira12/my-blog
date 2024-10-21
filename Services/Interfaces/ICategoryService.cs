using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Repositories;

namespace MyBlog.Services.Interfaces
{
    public interface ICategoryService
    {

        Task<ApiResponse<IEnumerable<Category>>> GetCategoriesAsync();   
        Task<ApiResponse<Category>> GetCategoryByIdAsync(Guid id);
        Task<ApiResponse<Category>> CreateCategoryAsync(Category category);
        Task<ApiResponse<Category>> UpdateCategoryAsync(Guid id, Category category);
        Task<ApiResponse<bool>> DeleteCategoryAsync(Guid id);
    }
}
