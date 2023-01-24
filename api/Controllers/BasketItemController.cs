using Business.BasketItemBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemController : ControllerBase
    {
        private readonly IBasketItemBusinessService _basketItemBusiness;
        public BasketItemController(IBasketItemBusinessService basketItemBusiness)
        {
            _basketItemBusiness = basketItemBusiness;
        }
        //[HttpPost]
        //[Route("Create")]
        //public async Task<IActionResult> Create([FromBody] BasketItemVM vM)
        //{
        //    var addBasket = _basketItemBusiness.CreateBasket(vM);
        //    if (addBasket.Result.Id == 0)
        //        return BadRequest("Insert Operation Failed.");

        //    return Ok(await addBasket);
        //}
    }
}
