
using Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            entity.CreatedAt = DateTime.Now.ToLocalTime();
            _dbContext.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public T Delete(T entity)
        {
            entity.DeletedAt = DateTime.Now.ToLocalTime();
            Update(entity);
            return entity;
        }

        public async Task<T> Find(int id)
        {
            return  Set().FindAsync(id).Result;
        }

        public async Task<IQueryable<T>> Get(Expression<Func<T, bool>> whereCondition)
        {
            return  Set().Where(whereCondition);
        }

        public async Task<T> GetFirst(Expression<Func<T, bool>> whereCondition)
        {
            return await Set().FirstOrDefaultAsync(whereCondition);
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
            entity.UpdatedAt = DateTime.Now.ToLocalTime();
            _dbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
