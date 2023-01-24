
using Context;
using Repository.ProductRepository;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private IProductRepositoryService _productRepository;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IProductRepositoryService ProductRepositoryService
        {
            get { return _productRepository = _productRepository ?? new ProductRepositoryService(_dbContext); }
        }

        public async Task CommitAsync()
        => await _dbContext.SaveChangesAsync();
    }
}
