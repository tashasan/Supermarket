using Entity;
using ViewModel;

namespace Business.CategoryBusiness
{
    public interface ICategoryBusinessService
    {
       Task <Category> CreateCategory(CategoryVM vM);
    }
}
