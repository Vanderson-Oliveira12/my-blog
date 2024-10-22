using MyBlog.Context;
using MyBlog.DTOs;
using MyBlog.Mappings;
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

        public async Task<ApiResponse<IEnumerable<ResponseCategoryDTO>>> GetCategoriesAsync()
        {

            var categories = await _baseRepository.GetAllAsync();

            var categoriesListDTO = CategoryMapping.categoryListToResponseCategoryDTOList(categories).ToList();

            return ApiResponse<IEnumerable<ResponseCategoryDTO>>.Success(data: categoriesListDTO);
        }

        public async Task<ApiResponse<ResponseCategoryDTO>> GetCategoryByIdAsync(Guid id)
        {
            var category = await _baseRepository.GetByIdAsync(id);

            if ( category == null )
            {
                return ApiResponse<ResponseCategoryDTO>.Fail(message: "Categoria não encontrada", statusCode: 400);
            }

            var categoryDTO = CategoryMapping.categoryToResponseCategoryDTO(category);

            return ApiResponse<ResponseCategoryDTO>.Success(categoryDTO);
        }

        public async Task<ApiResponse<CreateCategoryDTO>> CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            Category category = CategoryMapping.createCategoryDTOtoCategory(createCategoryDTO);

            var categoryCreated = await _baseRepository.CreateAsync(category);

            if ( categoryCreated == null )
            {
                return ApiResponse<CreateCategoryDTO>.Fail(message: "Não foi possível criar a sua categoria", statusCode: 400);
            }

            return ApiResponse<CreateCategoryDTO>.Success(createCategoryDTO);
        }

        public async Task<ApiResponse<Category>> UpdateCategoryAsync(Guid id, Category categoryDTO)
        {
            var category = await _baseRepository.GetByIdAsync(id);

            if ( category == null )
            {
                return ApiResponse<Category>.Fail(message: "Categoria não encontrada", statusCode: 404);
            }


            await _baseRepository.UpdateAsync(categoryDTO);

            return ApiResponse<Category>.Success(category);
        }
        public async Task<ApiResponse<bool>> DeleteCategoryAsync(Guid id)
        {
            var category = await _baseRepository.GetByIdAsync(id);

            if(category == null )
            {
                return ApiResponse<bool>.Fail(message: "Categoria não encontrada", statusCode: 404);
            }

            await _baseRepository.DeleteAsync(id);

            return ApiResponse<bool>.Success(data: true, message: "Categoria deletada com sucesso");
        }

    }
}
