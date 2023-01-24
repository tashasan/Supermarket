using Business.ProductBusiness;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductBusinessService _productBusiness;
        public ProductController(IProductBusinessService productBusiness)
        {
            _productBusiness = productBusiness;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] ProductVM vM)
        {
            var addProduct = _productBusiness.CreateProduct(vM);
            if (!addProduct.IsCompletedSuccessfully)
                return BadRequest("Insert Operation Failed.");

            return Ok(await addProduct);
        }
        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> Update(int id,[FromBody] ProductVM vM)
        {
            var editProduct = _productBusiness.EditProduct(id,vM);
            if (!editProduct.IsCompletedSuccessfully)
                return BadRequest("Update Operation Failed.");

            return Ok(await editProduct);
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removeProduct = _productBusiness.RemoveProduct(id);
            if (!removeProduct.IsCompletedSuccessfully)
                return BadRequest("");

            return Ok("Delete Operation Successfully Complated.");
        }
        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var addProduct = _productBusiness.GetProductById(id);
            if (addProduct.IsFaulted)
                return BadRequest("");

            return Ok(await addProduct);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var addProduct = _productBusiness.GetAllProducts();
            if (addProduct.IsFaulted)
                return BadRequest("");

            return Ok(await addProduct);
        }
    }
}
