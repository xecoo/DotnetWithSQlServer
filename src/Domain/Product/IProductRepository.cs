using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Domain.Product
{
    public interface IProductRepository : IRepositoryAsync<Product>
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
    }
}