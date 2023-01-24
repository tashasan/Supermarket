using Entity;
using ViewModel;

namespace Business.BasketItemBusiness
{
    public interface IBasketItemBusinessService
    {
        Task<BasketItem> CreateBasket(int basketId, BasketItemVM vM);
        Task<BasketItem> EditBasketItem(int id, int quantity );
        Task<BasketItem> RemoveBasketItem(int id);
        Task<List<BasketItem>> GetBasketItemsByBasketId(int basketId);
        Task<BasketItem> GetBasketItemById(int id);

    }
}
