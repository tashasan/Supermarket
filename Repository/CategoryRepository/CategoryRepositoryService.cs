using Context;
using Entity;

namespace Repository.CategoryRepository
{
    public class CategoryRepositoryService : BaseRepository<Category>, ICategoryRepositoryService
    {
        public CategoryRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
