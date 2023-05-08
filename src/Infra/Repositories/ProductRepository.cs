using System.Threading.Tasks;
using Project.Domain.Product;

namespace Project.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}