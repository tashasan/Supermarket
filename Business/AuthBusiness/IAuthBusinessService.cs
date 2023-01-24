using Entity;

namespace Business.AuthBusiness
{
    public interface IAuthBusinessService
    {
        Task<User> Login(string username, string password);
    }
}
