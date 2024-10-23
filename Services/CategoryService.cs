using FluentValidation;
using MyBlog.Context;
using MyBlog.DTOs;
using MyBlog.Mappings;
using MyBlog.Models;
using MyBlog.Repositories;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using MyBlog.Validations;
using System.ComponentModel.DataAnnotations;

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

        public async Task<ApiResponse<RequestCategoryDTO>> CreateCategoryAsync(RequestCategoryDTO createCategoryDTO)
        {
            Category category = CategoryMapping.requestCategoryDTOtoCategory(createCategoryDTO);

            var categoryCreated = await _baseRepository.CreateAsync(category);

            if ( categoryCreated == null )
            {
                return ApiResponse<RequestCategoryDTO>.Fail(message: "Não foi possível criar a sua categoria", statusCode: 400);
            }

            return ApiResponse<RequestCategoryDTO>.Success(createCategoryDTO);
        }

        public async Task<ApiResponse<ResponseCategoryDTO>> UpdateCategoryAsync(Guid id, RequestCategoryDTO requestCategoryDTO)
        {
            var category = await _baseRepository.GetByIdAsync(id);

            if ( category == null )
            {
                return ApiResponse<ResponseCategoryDTO>.Fail(message: "Categoria não encontrada", statusCode: 404);
            }

            if ( !String.IsNullOrEmpty(requestCategoryDTO.Title) )
            {
                category.ChangeTitle(requestCategoryDTO.Title);
            }

            if ( !String.IsNullOrEmpty(requestCategoryDTO.Description) )
            {
                category.ChangeTitle(requestCategoryDTO.Description);
            }

            await _baseRepository.UpdateAsync(category);

            var responseCategoryDTO = CategoryMapping.categoryToResponseCategoryDTO(category);

            return ApiResponse<ResponseCategoryDTO>.Success(responseCategoryDTO);
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
