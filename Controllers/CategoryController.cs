using Microsoft.AspNetCore.Mvc;
using MyBlog.Services.Interfaces;
using MyBlog.ViewModels;

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
        public async Task<ActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(categories);
        }


        [HttpGet("{id:Guid}")]
        public async Task<ActionResult> GetByIdAsync(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return category is null ? NotFound() : Ok(category);
        }


        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] CreateCategoryViewModel model)
        {
            if ( !ModelState.IsValid )
                return UnprocessableEntity(model);
        
            var categoryId = await _categoryService.CreateAsync(model);

            return StatusCode(201, categoryId);
        }


        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateCategoryViewModel model)
        {
            if ( !ModelState.IsValid )
                return UnprocessableEntity(model);

            var categoryId = await _categoryService.UpdateAsync(id, model);

            return Ok(categoryId);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] Guid id)
        {
            await _categoryService.DeleteAsync(id);

            return Ok();
        }
    }
}
