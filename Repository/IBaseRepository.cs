using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        DbSet<T> Set();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<T> Find(int id);
        Task<List<T>> List();
        Task<T> GetFirst(Expression<Func<T, bool>> whereCondition);
        Task<IQueryable<T>> Get(Expression<Func<T, bool>> whereCondition);
    }
}
