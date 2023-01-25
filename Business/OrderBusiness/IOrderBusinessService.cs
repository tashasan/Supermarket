
using Entity;
using ViewModel;

namespace Business.OrderBusiness
{
    public interface IOrderBusinessService
    {
        Task<Order> CreateOrder(int basketId,OrderVM vM);
    }
}
