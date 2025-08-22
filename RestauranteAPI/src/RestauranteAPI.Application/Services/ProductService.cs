using RestauranteAPI.Application.Interfaces;
using RestauranteAPI.Domain.Entities;
using RestauranteAPI.Domain.Repositories;

namespace RestauranteAPI.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // Cria um novo produto
        public async Task<Product> CreateProductAsync(string name, decimal price)
        {
            // Usa o construtor público da entidade
            var product = new Product(name, price);

            await _productRepository.AddAsync(product);
            return product;
        }

        // Atualiza um produto existente
        public async Task UpdateProductAsync(int id, string name, decimal price)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new InvalidOperationException("Produto não encontrado.");

            product.UpdateName(name);
            product.UpdatePrice(price);

            await _productRepository.UpdateAsync(product);
        }

        // Retorna todos os produtos
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        // Busca produto por ID
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        // Deleta produto
        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
