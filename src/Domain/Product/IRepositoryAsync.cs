using System.Threading.Tasks;

namespace Project.Domain
{
    public interface IRepositoryAsync<T>
        where T : class
    {
        Task<T> CreateAsync(T obj);
        Task UpdateAsync(T obj);
        void Insert(T obj);
        void Update (T obj);
    }
}