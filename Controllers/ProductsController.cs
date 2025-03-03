using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagementAPI.DTOs;
using ProductManagementAPI.Models;
using ProductManagementAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductManagementAPI.Services;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/products")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation("Fetching all products");
            var products = await _repository.GetAllProducts();
            var productDTOs = new List<ProductDTO>();

            foreach (var product in products)
            {
                productDTOs.Add(new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                });
            }

            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repository.GetProductById(id);
            if (product == null)
            {
                _logger.LogWarning("Product with ID {ProductId} not found", id);
                return NotFound(new { message = "Product not found" });
            }

            return Ok(new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest(new { message = "Invalid product data" });

            await _repository.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            var product = await _repository.GetProductById(id);
            if (product == null)
                return NotFound(new { message = "Product not found" });

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            await _repository.UpdateProduct(product);
            return Ok(new { message = "Product updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repository.GetProductById(id);
            if (product == null)
                return NotFound(new { message = "Product not found" });

            await _repository.DeleteProduct(id);
            return Ok(new { message = "Product deleted successfully" });
        }
    }
}
