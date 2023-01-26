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

            return Ok( addProduct);
        }
        [HttpPut]
        [Route("Update/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductVM vM)
        {
            var editProduct = _productBusiness.EditProduct(id, vM);
            if (!editProduct.IsCompletedSuccessfully)
                return BadRequest("Update Operation Failed.");

            return Ok(editProduct.Result);
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removeProduct = _productBusiness.RemoveProduct(id).Result;
            if (removeProduct.Id == null)
                return BadRequest("");
            string message = "Delete Operation Successfully Complated.";
            return Ok(message);
        }
        [HttpGet]
        [Route("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var addProduct = _productBusiness.GetProductById(id);
            if (addProduct.IsFaulted)
                return BadRequest("");

            return Ok( addProduct.Result);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var getProduct = _productBusiness.GetAllProducts();
            if (getProduct.IsFaulted)
                return BadRequest("");

            return Ok(getProduct.Result);
        }
    }
}
