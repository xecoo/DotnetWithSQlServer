using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Product;
using Project.Infra.Data;

namespace Project.Infra.Repositories
{
    public class ProductRepository : RepositoryAsync<Product>, IProductRepository
    {
        public ProductRepository(
            ProductDbContext context) 
            : base(context)
        {}

        public async Task<List<Product>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet
                        .Where(x => x.Id == id)
                        .FirstAsync();
        }
    }
}