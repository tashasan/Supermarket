using Entity;
using Repository;

namespace Business.BasketBusiness
{
    public class BasketBusinessService : IBasketBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BasketBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Basket> CreateBasket(int userId)
        {
            try
            {
                Basket model = new Basket();
                var checkBasket = _unitOfWork.BasketRepositoryService.GetFirst(a => a.UserId == userId && a.isSold == false);
                if (checkBasket.Result == null || checkBasket.Result.isSold == true)
                {
                    model.UserId = userId;
                    model.isSold = false;
                    _unitOfWork.BasketRepositoryService.Add(model);
                    await _unitOfWork.CommitAsync();
                }
                else { model.Id = checkBasket.Result.Id; }

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Basket>> GetAllBasketItems()
        {
            throw new NotImplementedException();
        }

        public Task<Basket> GetBasketItemById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> RemoveBasketItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Basket> UpdateBasket(int id)
        {
            try
            {
                var checkBasket = _unitOfWork.BasketRepositoryService.Find(id).Result;
                var getSup = _unitOfWork.BasketItemRepositoryService.Get(b => b.BasketId == id).Result.Select(s => s.TotalPrice).ToArray();
                decimal total = getSup.Sum();
                _unitOfWork.BasketRepositoryService.Update(checkBasket);
                _unitOfWork.CommitAsync();
                return checkBasket;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
