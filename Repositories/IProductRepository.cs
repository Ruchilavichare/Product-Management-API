using ProductManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
