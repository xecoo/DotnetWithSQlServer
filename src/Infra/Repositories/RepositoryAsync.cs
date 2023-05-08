using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Domain;

namespace Project.Infra.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T>
        where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryAsync(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> CreateAsync(T obj)
        {
            var entity = _dbSet.Add(obj);
            entity.State = EntityState.Added;

            await _context.SaveChangesAsync();

            return obj;
        }

        public async Task UpdateAsync(T obj)
        {
            var entity = _dbSet.Update(obj);
            entity.State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public void Insert(T obj)
        {
            var entity = _dbSet.Add(obj);
            entity.State = EntityState.Added;
        }

        public void Update(T obj)
        {
            var entity = _dbSet.Update(obj);
            entity.State = EntityState.Modified;
        }
    }
}