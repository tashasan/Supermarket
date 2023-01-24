using Entity;
using Repository;
using ViewModel;

namespace Business.CategoryBusiness
{
    public class CategoryBusinessService : ICategoryBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategory(CategoryVM vM)
        {
            try
            {
                Category model = new Category();
                var isExist = _unitOfWork.CategoryRepositoryService.GetFirst(c => c.CategoryName == vM.CategoryName);
                if (isExist.Result == null)
                {
                    model.CategoryName = vM.CategoryName;
                    var result = _unitOfWork.CategoryRepositoryService.Add(model);
                    await _unitOfWork.CommitAsync();
                }
                return model;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
