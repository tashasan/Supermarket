using Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        DbSet<T> Set();
        Task<T> Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<T> Find(int id);
        Task<List<T>> List();
    }
}
