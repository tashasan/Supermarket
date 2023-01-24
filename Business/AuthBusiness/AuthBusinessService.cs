using Entity;
using Repository;

namespace Business.AuthBusiness
{
    public class AuthBusinessService : IAuthBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<User> Login(string username, string password)
        {
            var getUser = _unitOfWork.UserRepositoryService.GetFirst(u => u.Email == username && u.Password == password);
            return getUser;
        }
    }
}
