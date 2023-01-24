
using Context;
using Repository.BasketItemRepository;
using Repository.BasketRepository;
using Repository.CategoryRepository;
using Repository.OrderRepository;
using Repository.ProductRepository;
using Repository.UserRepository;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        private IProductRepositoryService _productRepository;
        private ICategoryRepositoryService _categoryRepository;
        private IUserRepositoryService _userRepository;
        private IOrderRepositoryService _orderRepository;
        private IBasketRepositoryService _basketRepositoryService;
        private IBasketItemRepositoryService _basketItemRepository;
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IProductRepositoryService ProductRepositoryService
        {
            get { return _productRepository = _productRepository ?? new ProductRepositoryService(_dbContext); }
        }

        public ICategoryRepositoryService CategoryRepositoryService
        {
            get { return _categoryRepository = _categoryRepository ?? new CategoryRepositoryService(_dbContext); }
        }
        public IUserRepositoryService UserRepositoryService
        {
            get { return _userRepository = _userRepository ?? new UserRepositoryService(_dbContext); }
        }
        public IOrderRepositoryService OrderRepositoryService
        {
            get { return _orderRepository = _orderRepository ?? new OrderRepositoryService(_dbContext); }
        }
        public IBasketRepositoryService BasketRepositoryService
        {
            get { return _basketRepositoryService = _basketRepositoryService ?? new BasketRepositoryService(_dbContext); }
        }
        public IBasketItemRepositoryService BasketItemRepositoryService
        {
            get { return _basketItemRepository = _basketItemRepository ?? new BasketItemRepositoryService(_dbContext); }
        }
        public async Task CommitAsync()
        => await _dbContext.SaveChangesAsync();
    }
}
