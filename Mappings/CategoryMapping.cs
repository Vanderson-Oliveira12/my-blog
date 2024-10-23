using MyBlog.DTOs;
using MyBlog.Models;
using MyBlog.ViewModels;

namespace MyBlog.Mappings
{
    public static class CategoryMapping
    {
        public static Category AsEntity(this CreateCategoryViewModel? model)
           => model is null
            ? null
            : new Category(title: model.Title, description: model.Description);

        public static Category AsEntity(this UpdateCategoryViewModel? model)
           => model is null
            ? null
            : new Category(title: model.Title, description: model.Description);


        public static CategoryDTO AsDTO(this Category? model)
           => model is null
            ? null
            : new CategoryDTO { Id = model.Id, Title = model.Title, Description = model.Description };

        public static IEnumerable<CategoryDTO> AsEnumerableDTO(this IEnumerable<Category>? model)
            => model is null
            ? null
            : model.Select(AsDTO).ToArray();

    }
}
