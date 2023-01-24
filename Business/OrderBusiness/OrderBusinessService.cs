using Repository;

namespace Business.OrderBusiness
{
    public class OrderBusinessService : IOrderBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
