using Entity;
using Repository;
using ViewModel;

namespace Business.BasketItemBusiness
{
    public class BasketItemBusinessService : IBasketItemBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BasketItemBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasketItem> CreateBasket(int basketId, BasketItemVM vM)
        {
            try
            {
                BasketItem model = new BasketItem();
                var checkStock = _unitOfWork.ProductRepositoryService.GetFirst(p => p.Id == vM.ProductId).Result;
                if (checkStock.Stock >= vM.Quantity)
                {
                    model.Quantity = vM.Quantity;
                    model.ProductId = vM.ProductId;
                    model.TotalPrice = checkStock.UnitPrice * vM.Quantity;
                    model.BasketId = basketId;
                    var result = _unitOfWork.BasketItemRepositoryService.Add(model);
                    await _unitOfWork.CommitAsync();
                }

                return model;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<BasketItem> EditBasketItem(int id, int quantity)
        {
            try
            {
                var getBasket = _unitOfWork.BasketItemRepositoryService.GetFirst(u => u.Id == id);
                var checkStock = _unitOfWork.ProductRepositoryService.GetFirst(p => p.Id == getBasket.Result.ProductId).Result;
                getBasket.Result.Quantity = quantity;
                getBasket.Result.TotalPrice = checkStock.UnitPrice * quantity;
                var result = _unitOfWork.BasketItemRepositoryService.Update(getBasket.Result);
                 _unitOfWork.CommitAsync();
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<BasketItem>> GetBasketItemsByBasketId(int basketId)
        {
            try
            {
                var result = _unitOfWork.BasketItemRepositoryService.Get(x => x.BasketId == basketId && x.DeletedAt == null).Result.ToList();
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<BasketItem> GetBasketItemById(int id)
        {
            try
            {
                var getId =  _unitOfWork.BasketItemRepositoryService.GetFirst(a => a.Id == id);
                var result = _unitOfWork.BasketItemRepositoryService.Find(getId.Id);
                return result.Result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<BasketItem> RemoveBasketItem(int id)
        {
            try
            {
                var getBasket = _unitOfWork.BasketItemRepositoryService.GetFirst(u => u.Id == id && u.DeletedAt == null);
                if (getBasket.Result == null)
                {
                  return null;
                }
                var result = _unitOfWork.BasketItemRepositoryService.Delete(getBasket.Result);
                _unitOfWork.CommitAsync();
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
