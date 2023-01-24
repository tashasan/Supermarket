
using Context;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            entity.DeletedAt = DateTime.Now;
            Update(entity);
            return entity;
        }

        public async Task<T> Find(int id)
        {
            return await Set().FindAsync(id);
        }

        public async Task<List<T>> List()
        {
            return await Set().ToListAsync();
        }

        public DbSet<T> Set()
        {
            return _dbContext.Set<T>();
        }

        public T Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }   
    }
}
