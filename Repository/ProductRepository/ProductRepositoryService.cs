using Context;
using Entity;

namespace Repository.ProductRepository
{
    public class ProductRepositoryService:BaseRepository<Product>, IProductRepositoryService
    {
        public ProductRepositoryService(ApplicationDbContext dbContext):base(dbContext) 
        {

        }
    }
}
