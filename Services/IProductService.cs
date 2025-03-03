using ProductManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task AddProduct(Product product);
    }
}
