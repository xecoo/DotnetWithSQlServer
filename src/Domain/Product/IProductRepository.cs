using System.Threading.Tasks;

namespace Project.Domain.Product
{
    public interface IProductRepository
    {
        Task<Product> GetAll();
        Task<Product> GetById(int id);
        
    }
}