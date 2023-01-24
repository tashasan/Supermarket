using Business.CategoryBusiness;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryBusinessService _categoryBusiness;
        public CategoryController(ICategoryBusinessService categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryVM vM)
        {
            var addCategory = _categoryBusiness.CreateCategory(vM);
            if (addCategory.Result.Id == 0)
                return BadRequest("Insert Operation Failed.");

            return Ok(await addCategory);
        }
    }
}
