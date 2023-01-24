using Business.BasketBusiness;
using Business.BasketItemBusiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketBusinessService _basketBusinessService;
        private readonly IBasketItemBusinessService _basketItemBusiness;
        public BasketController(IBasketBusinessService basketBusinessService, IBasketItemBusinessService basketItemBusinessService)
        {
            _basketBusinessService = basketBusinessService;
            _basketItemBusiness = basketItemBusinessService;
        }

        [HttpPost]
        [Route("Create/{userId:int}")]
        public async Task<IActionResult> Create(int userId, [FromBody] BasketItemVM vM)
        {
            var addBasket = _basketBusinessService.CreateBasket(userId);
            var creatSup = _basketItemBusiness.CreateBasket(addBasket.Result.Id, vM);
            if (addBasket.Result.Id == 0)
                return BadRequest("Insert Operation Failed.");

            return Ok(await addBasket);
        }
        [HttpPut]
        [Route("Update/{id:int}/{quantity:int}")]
        public async Task<IActionResult> Update(int id, int quantity)
        {
            var editBasket = _basketItemBusiness.EditBasketItem(id, quantity);
            if (!editBasket.IsCompletedSuccessfully)
                return BadRequest("Update Operation Failed.");

            return Ok(editBasket);
        }
    }
}
