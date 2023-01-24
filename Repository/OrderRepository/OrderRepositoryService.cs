using Context;
using Entity;

namespace Repository.OrderRepository
{
    public class OrderRepositoryService : BaseRepository<Order>, IOrderRepositoryService
    {
        public OrderRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
