using Repository.BasketItemRepository;
using Repository.BasketRepository;
using Repository.CategoryRepository;
using Repository.OrderRepository;
using Repository.ProductRepository;
using Repository.UserRepository;

namespace Repository
{
    public interface IUnitOfWork
    {
        IProductRepositoryService ProductRepositoryService { get; }
        ICategoryRepositoryService CategoryRepositoryService { get; }
        IUserRepositoryService UserRepositoryService { get; }
        IOrderRepositoryService OrderRepositoryService { get; }
        IBasketRepositoryService BasketRepositoryService { get; }
        IBasketItemRepositoryService BasketItemRepositoryService { get; }
        Task CommitAsync();
    }
}
