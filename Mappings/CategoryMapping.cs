using MyBlog.DTOs;
using MyBlog.Models;

namespace MyBlog.Mappings
{
    public class CategoryMapping
    {
        public static RequestCategoryDTO categoryToRequestCategoryDTO (Category category)
        {
            return new RequestCategoryDTO
            {
               Title = category.Title,
               Description = category.Description,
            };
        }

        public static Category requestCategoryDTOtoCategory(RequestCategoryDTO requestCategoryDTO)
        {
            return new Category(title: requestCategoryDTO.Title, description: requestCategoryDTO.Description);
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
