
using Entity;
using ViewModel;

namespace Business.BasketBusiness
{
    public interface IBasketBusinessService
    {
        Task<Basket> CreateBasket(int userId);
        Task<Basket> UpdateBasket(int id);
        Task<Basket> RemoveBasketItem(int id);
        Task<List<Basket>> GetAllBasketItems();
        Task<Basket> GetBasketIdByUserId(int id);
    }
}
