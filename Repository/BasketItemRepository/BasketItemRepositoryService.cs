using Context;
using Entity;

namespace Repository.BasketItemRepository
{
    public class BasketItemRepositoryService : BaseRepository<BasketItem>, IBasketItemRepositoryService
    {
        public BasketItemRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
