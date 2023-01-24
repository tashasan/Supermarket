using Repository.ProductRepository;

namespace Repository
{
    public interface IUnitOfWork
    {
        IProductRepositoryService ProductRepositoryService { get; }

        Task CommitAsync();
    }
}
