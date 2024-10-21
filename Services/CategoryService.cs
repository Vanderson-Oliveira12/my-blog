using MyBlog.Context;
using MyBlog.Models;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;

namespace MyBlog.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IBaseRepository<Category> _baseRepository;

        public CategoryService(IBaseRepository<Category> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<ApiResponse<IEnumerable<Category>>> GetCategoriesAsync()
        {

            var categories = await _baseRepository.GetAllAsync();

            return ApiResponse<IEnumerable<Category>>.Success(data: categories);
        }

        public Task<ApiResponse<Category>> GetCategoryByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Category>> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<Category>> UpdateCategoryAsync(Guid id, Category category)
        {
            throw new NotImplementedException();
        }
        public Task<ApiResponse<bool>> DeleteCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
