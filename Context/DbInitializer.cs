using Entity;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;

        }

        public void Seed()
        {
            User user = new User()
            {
                Id = 1,
                Email = "example@msn.com",
                Password = "trustme",
                FirstName = "Jon",
                LastName = "Brown",
                PhoneNumber = "905001112233"
            };
            _modelBuilder.Entity<User>().HasData(user);
        }
    }
}
