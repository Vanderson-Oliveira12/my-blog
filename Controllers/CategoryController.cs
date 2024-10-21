using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;
using MyBlog.Services.Interfaces;

namespace MyBlog.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<Category>>>> GetAllCategoriesAsync()
        {
           var response = await _categoryService.GetCategoriesAsync();

            if ( response.IsSuccessful ) {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Category>>> GetCategoryByIdAsync(Guid id)
        {
            var response = await _categoryService.GetCategoryByIdAsync(id);

            if ( response.IsSuccessful )
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }


        [HttpPost]
        public async Task<ActionResult<ApiResponse<Category>>> CreateCategoryAsync([FromBody] Category categoryModel)
        {
            var response = await _categoryService.CreateCategoryAsync(categoryModel);

            if ( response.IsSuccessful )
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<Category>>>> UpdateCategoryAsync(Guid id, [FromBody] Category categoryModel)
        {
            var response = await _categoryService.UpdateCategoryAsync(id, categoryModel);

            if ( response.IsSuccessful )
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteCategoryAsync(Guid id)
        {
            var response = await _categoryService.DeleteCategoryAsync(id);

            if ( response.IsSuccessful )
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }


    }
}
