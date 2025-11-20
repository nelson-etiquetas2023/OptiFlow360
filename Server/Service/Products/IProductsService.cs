using Shared.Models;

namespace Server.Service.Products
{
    public interface IProductsService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product producto);
        Task<Product?> UpdateProductAsync(int id, Product producto);
        Task<bool> DeleteProductAsync(int id);
    }
}
