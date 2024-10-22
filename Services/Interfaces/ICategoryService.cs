using MyBlog.Models;
using MyBlog.Repositories.Interfaces;
using MyBlog.Repositories;
using MyBlog.DTOs;

namespace MyBlog.Services.Interfaces
{
    public interface ICategoryService
    {

        Task<ApiResponse<IEnumerable<ResponseCategoryDTO>>> GetCategoriesAsync();   
        Task<ApiResponse<ResponseCategoryDTO>> GetCategoryByIdAsync(Guid id);
        Task<ApiResponse<CreateCategoryDTO>> CreateCategoryAsync(CreateCategoryDTO createCategoryDTO);
        Task<ApiResponse<Category>> UpdateCategoryAsync(Guid id, Category category);
        Task<ApiResponse<bool>> DeleteCategoryAsync(Guid id);
    }
}
