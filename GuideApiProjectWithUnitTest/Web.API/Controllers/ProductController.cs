using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private readonly IService<Product> _service;
        private readonly IProductService _productService;

        public ProductController(IService<Product> service, IProductService productService)
        {
            _service = service;
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _service.AddAsync(product);
            return StatusCode(StatusCodes.Status201Created, product);
        }

        // GET api/products/GetProductsWithCategory
        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            var products = await _productService.GetProductsWithCategory();
            return Ok(products);
        }

        // GET api/products/GetProducByIdWithCategory
        [HttpGet("GetProducByIdWithCategory")]
        public async Task<IActionResult> GetProducByIdWithCategory(int id)
        {
            var products = await _productService.GetProductsWithCategory();
            var targetProduct = products.FirstOrDefault(x => x.Id == id);

            if (targetProduct != null)
                return Ok(targetProduct);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            else
                return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await _service.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
            await _service.RemoveAsync(product);
            return NoContent();
            }
        }
    }
}
