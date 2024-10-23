using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyBlog.CustomExtensions;
using MyBlog.DTOs;
using MyBlog.Models;
using MyBlog.Services.Interfaces;
using MyBlog.Validations;

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
        public async Task<ActionResult<ApiResponse<RequestCategoryDTO>>> CreateCategoryAsync([FromBody] RequestCategoryDTO requestCategoryDTO)
        {

            if ( !ModelState.IsValid )
            {
                var errorModel = ModelState.FailInValidateModel<RequestCategoryDTO>();

                return BadRequest(errorModel);
            }


            var response = await _categoryService.CreateCategoryAsync(requestCategoryDTO);

            if ( response.IsSuccessful )
            {
                return Ok(response);
            }

            return StatusCode(response.StatusCode, response);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<ResponseCategoryDTO>>> UpdateCategoryAsync(Guid id, [FromBody] RequestCategoryDTO requestCategoryDTO)
        {

            CategoryValidator validator = new CategoryValidator();

            ValidationResult result = validator.Validate(requestCategoryDTO);

            if ( !result.IsValid ) {

                var responseModel = result.FailInValidateFluentModel<ResponseCategoryDTO>();

                return BadRequest(responseModel);
            }

            var response = await _categoryService.UpdateCategoryAsync(id, requestCategoryDTO);

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
