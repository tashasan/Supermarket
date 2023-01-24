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
                PhoneNumber = "905001112233",
                CreatedAt = DateTime.Now.ToLocalTime(),
            };
            _modelBuilder.Entity<User>().HasData(user);

            var categories = new Category[]
            {
                new Category() {Id=1,CategoryName="Staple Food",CreatedAt=DateTime.Now.ToLocalTime()},
                new Category() {Id=2,CategoryName="Chocolates",CreatedAt=DateTime.Now.ToLocalTime()},
                new Category() {Id=3,CategoryName="Drinks",CreatedAt=DateTime.Now.ToLocalTime()},

            };
            _modelBuilder.Entity<Category>().HasData(categories);

            var product = new Product[]
            {
                new Product() {Id=1,CategoryId=1,Name="Liquid Oil",Stock=100,UnitPrice=25,CreatedAt=DateTime.Now.ToLocalTime()},
                new Product() {Id=2,CategoryId=1,Name="Flour",Stock=80,UnitPrice=12,CreatedAt=DateTime.Now.ToLocalTime()},
                new Product() {Id=3,CategoryId=2,Name="Nutella",Stock=40,UnitPrice=18,CreatedAt=DateTime.Now.ToLocalTime()},
                new Product() {Id=4,CategoryId=3,Name="Soda",Stock=30,UnitPrice=8,CreatedAt=DateTime.Now.ToLocalTime()},
                new Product() {Id=5,CategoryId=3,Name="Water",Stock=90,UnitPrice=5,CreatedAt=DateTime.Now.ToLocalTime()},
            };
            _modelBuilder.Entity<Product>().HasData(product);
        }
    }
}
