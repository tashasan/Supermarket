using Business.AuthBusiness;
using Business.BasketBusiness;
using Business.BasketItemBusiness;
using Business.CategoryBusiness;
using Business.OrderBusiness;
using Business.ProductBusiness;
using Context;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.BasketItemRepository;
using Repository.BasketRepository;
using Repository.CategoryRepository;
using Repository.OrderRepository;
using Repository.ProductRepository;
using Repository.UserRepository;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepositoryService, ProductRepositoryService>();
builder.Services.AddScoped<IProductBusinessService, ProductBusinessService>();
builder.Services.AddScoped<ICategoryRepositoryService, CategoryRepositoryService>();
builder.Services.AddScoped<ICategoryBusinessService, CategoryBusinessService>();
builder.Services.AddScoped<IUserRepositoryService, UserRepositoryService>();
builder.Services.AddScoped<IAuthBusinessService, AuthBusinessService>();
builder.Services.AddScoped<IOrderRepositoryService, OrderRepositoryService>();
builder.Services.AddScoped<IOrderBusinessService, OrderBusinessService>();
builder.Services.AddScoped<IOrderBusinessService, OrderBusinessService>();
builder.Services.AddScoped<IBasketRepositoryService, BasketRepositoryService>();
builder.Services.AddScoped<IBasketBusinessService, BasketBusinessService>();
builder.Services.AddScoped<IBasketItemRepositoryService, BasketItemRepositoryService>();
builder.Services.AddScoped<IBasketItemBusinessService, BasketItemBusinessService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(builder => builder.WithOrigins("https://localhost:3000").AllowCredentials().AllowAnyHeader().AllowAnyMethod());

app.Run();
