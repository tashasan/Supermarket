using Context;
using Entity;

namespace Repository.UserRepository
{
    public class UserRepositoryService:BaseRepository<User>, IUserRepositoryService
    {
        public UserRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
