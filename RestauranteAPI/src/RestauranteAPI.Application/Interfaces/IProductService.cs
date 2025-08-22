using RestauranteAPI.Domain.Entities;

namespace RestauranteAPI.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> CreateProductAsync(string name, decimal price);
        Task UpdateProductAsync(int id, string name, decimal price);
    }
}
