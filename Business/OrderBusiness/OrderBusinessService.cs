using Entity;
using Repository;
using ViewModel;

namespace Business.OrderBusiness
{
    public class OrderBusinessService : IOrderBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(int basketId, OrderVM vM)
        {
            try
            {
                var getBasketItem = _unitOfWork.BasketItemRepositoryService.GetFirst(f => f.BasketId == basketId).Result;
                var getProduct = _unitOfWork.ProductRepositoryService.GetFirst(p => p.Id == getBasketItem.ProductId).Result;
                var getSup = _unitOfWork.BasketItemRepositoryService.Get(b => b.BasketId == basketId).Result.Select(s => s.TotalPrice).ToArray();
                var getPorudctIds = _unitOfWork.BasketItemRepositoryService.Get(p => p.BasketId == basketId).Result.Select(s => s.ProductId).ToArray();
                foreach (var i in getPorudctIds)
                {
                    var totalAmount = _unitOfWork.BasketItemRepositoryService.GetFirst(o => o.ProductId == i).Result;
                    var productStock = _unitOfWork.ProductRepositoryService.GetFirst(p => p.Id == i).Result;
                    productStock.Stock = productStock.Stock - totalAmount.Quantity;
                    _unitOfWork.ProductRepositoryService.Update(productStock);
                }
                decimal total = getSup.Sum();
                Order model = new Order();
                model.PaymentType = vM.PaymentType;
                model.TotalAmount = total;
                model.BasketId = basketId;
                var result = _unitOfWork.OrderRepositoryService.Add(model);
                var getBasket = _unitOfWork.BasketRepositoryService.GetFirst(a => a.Id == basketId).Result;
                getBasket.isSold = true;
                var update = _unitOfWork.BasketRepositoryService.Update(getBasket);

                var getQuantities = _unitOfWork.BasketItemRepositoryService.Get(q => q.ProductId == getBasketItem.ProductId).Result.Where(w => w.BasketId == basketId).Select(g => g.Quantity);
                //var stock = _unitOfWork.ProductRepositoryService.Update();
                _unitOfWork.CommitAsync();
                return model;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
