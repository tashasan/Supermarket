using Entity;
using Repository;
using ViewModel;

namespace Business.ProductBusiness
{
    public class ProductBusinessService : IProductBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> CreateProduct(ProductVM vM)
        {
            try
            {
                Product model = new Product();
                var isExist = _unitOfWork.ProductRepositoryService.GetFirst(c => c.Name == vM.ProductName);
                if (isExist.Result == null)
                {
                    model.Name = vM.ProductName;
                    model.Stock = vM.ProductStock;
                    model.UnitPrice = vM.ProductUnitPrice;
                    model.CategoryId = vM.CategoryId;
                    var result = _unitOfWork.ProductRepositoryService.Add(model);
                    await _unitOfWork.CommitAsync();
                }
                return model;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                var result = _unitOfWork.ProductRepositoryService.Get(x => x.DeletedAt == null).Result.ToList();
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var getId = await _unitOfWork.ProductRepositoryService.GetFirst(a => a.Id == id);
                var result = _unitOfWork.ProductRepositoryService.Find(getId.Id);
                return result.Result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Product> RemoveProduct(int id)
        {
            try
            {
                var getProduct = await _unitOfWork.ProductRepositoryService.Find(id);
                var result = _unitOfWork.ProductRepositoryService.Delete(getProduct);
                await _unitOfWork.CommitAsync();
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Product> EditProduct(int id, ProductVM vM)
        {
            try
            {
                var getProduct = await _unitOfWork.ProductRepositoryService.Find(id);

                getProduct.Name = vM.ProductName;
                getProduct.Stock = vM.ProductStock;
                getProduct.UnitPrice = vM.ProductUnitPrice;
                getProduct.CategoryId = vM.CategoryId;
                var result = _unitOfWork.ProductRepositoryService.Update(getProduct);
                await _unitOfWork.CommitAsync();
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
