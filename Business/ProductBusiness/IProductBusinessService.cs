using Entity;
using ViewModel;

namespace Business.ProductBusiness
{
    public interface IProductBusinessService
    {
        Task<Product> CreateProduct(ProductVM vM);
        Task<Product> EditProduct(int id,ProductVM vM);
        Task<Product> RemoveProduct(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
    }
}
