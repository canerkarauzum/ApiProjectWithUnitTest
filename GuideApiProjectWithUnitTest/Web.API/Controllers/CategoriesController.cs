using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController: ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/products/GetCategoryByIdWithProducts
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoryByIdWithProducts(int categoryId)
        {
            var category = await _categoryService.GetCategoryByIdWithProduct(categoryId);

            if(category == null)
            {
                return NotFound();
            }
            else
                return Ok(category);
        }

        // GET api/products/GetCategoriesWithProducts
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoriesWithProducts()
        {
            var categories = await _categoryService.GetCategoriesWithProducts();
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.AddAsync(category);
            return StatusCode(StatusCodes.Status201Created, category);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            else
                return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            await _categoryService.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                await _categoryService.RemoveAsync(category);
                return NoContent();
            }
        }
    }
}
