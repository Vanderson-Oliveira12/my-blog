using MyBlog.DTOs;
using MyBlog.Models;

namespace MyBlog.Mappings
{
    public class CategoryMapping
    {
        public static CreateCategoryDTO categoryToCreateCategoryDTO (Category category)
        {
            return new CreateCategoryDTO
            {
               Title = category.Title,
               Description = category.Description,
            };
        }

        public static Category createCategoryDTOtoCategory(CreateCategoryDTO createCategoryDTO)
        {
            return new Category(title: createCategoryDTO.Title, description: createCategoryDTO.Description);
        }

        public static ResponseCategoryDTO categoryToResponseCategoryDTO(Category category) {
            return new ResponseCategoryDTO(id: category.Id, title: category.Title, description: category.Description);
        }

        public static IEnumerable<ResponseCategoryDTO> categoryListToResponseCategoryDTOList(IEnumerable<Category> categoryList)
        {
            var responseCategoryDTOList = new List<ResponseCategoryDTO>();

            foreach(var category in categoryList)
            {

                ResponseCategoryDTO responseCategoryItem = new ResponseCategoryDTO(id: category.Id, title: category.Title, description: category.Description);

                responseCategoryDTOList.Add(responseCategoryItem);
            }

            return responseCategoryDTOList;
        }
    }
}
