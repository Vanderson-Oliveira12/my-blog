using MyBlog.DTOs;
using MyBlog.Mappings;
using MyBlog.Repositories.Interfaces;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;

namespace MyBlog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            return categories.AsEnumerableDTO();
        }

        public async Task<CategoryDTO> GetByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            return category.AsDTO();
        }

        public async Task<Guid> CreateAsync(CreateCategoryViewModel model)
        {
            var category = model.AsEntity();

            _categoryRepository.Create(category);

            await _categoryRepository.UnitOfWork.SaveChangesAsync();

            return category.Id;
        }

        public async Task<Guid> UpdateAsync(Guid id, UpdateCategoryViewModel model)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if ( category == null )
                throw new Exception("Categoria não existe");

            var categoryUpdated = model.AsEntity();
          
            category.SetTitle(categoryUpdated.Title);
            category.SetDescription(categoryUpdated.Description);

           _categoryRepository.Update(category);

           await _categoryRepository.UnitOfWork.SaveChangesAsync();

            return category.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);

            if ( category == null )
                throw new Exception("Categoria não existe");

            _categoryRepository.Delete(category);

            await _categoryRepository.UnitOfWork.SaveChangesAsync();
        }

    }
}
