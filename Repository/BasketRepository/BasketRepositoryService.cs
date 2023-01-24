using Context;
using Entity;

namespace Repository.BasketRepository
{
    public class BasketRepositoryService : BaseRepository<Basket>, IBasketRepositoryService
    {
        public BasketRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
