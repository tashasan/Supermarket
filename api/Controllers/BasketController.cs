using Business.BasketBusiness;
using Business.BasketItemBusiness;
using Business.OrderBusiness;
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
        private readonly IOrderBusinessService _orderBusinessService;
        public BasketController(IBasketBusinessService basketBusinessService, IBasketItemBusinessService basketItemBusinessService,
                                   IOrderBusinessService orderBusinessService)
        {
            _basketBusinessService = basketBusinessService;
            _basketItemBusiness = basketItemBusinessService;
            _orderBusinessService = orderBusinessService;
        }

        [HttpPost]
        [Route("Create/{userId:int}")]
        public async Task<IActionResult> Create(int userId, [FromBody] BasketItemVM vM)
        {
            var addBasket = _basketBusinessService.CreateBasket(userId).Result;
            var creatSup = _basketItemBusiness.CreateBasket(addBasket.Id, vM);
            if (addBasket.Id == 0)
                return BadRequest("Insert Operation Failed.");

            return Ok(addBasket);
        }
        [HttpPut]
        [Route("Update/{id:int}/{quantity:int}")]
        public async Task<IActionResult> Update(int id, int quantity)
        {
            var editBasket = _basketItemBusiness.EditBasketItem(id, quantity);
            if (!editBasket.IsCompletedSuccessfully)
                return BadRequest("Update Operation Failed.");

            return Ok(await editBasket);
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removeBasketItem = _basketItemBusiness.RemoveBasketItem(id);
            if (!removeBasketItem.IsCompletedSuccessfully || removeBasketItem.Result == null)
                return BadRequest("Already Deleted.");

            return Ok("Delete Operation Successfully Complated.");
        }
        [HttpGet]
        [Route("GetByBasketId/{basketId:int}")]
        public async Task<IActionResult> GetByBasketId(int basketId)
        {
            var getList = _basketItemBusiness.GetBasketItemsByBasketId(basketId);

            if (getList.IsFaulted)
                return BadRequest("");

            return Ok(await getList);
        }
        [HttpPost]
        [Route("Purchase/{basketId:int}")]
        public async Task<IActionResult> Purchase(int basketId, OrderVM vM)
        {
            var purchaseOrder = _orderBusinessService.CreateOrder(basketId, vM);
            if (!purchaseOrder.IsCompletedSuccessfully)
                return BadRequest("");

            return Ok(await purchaseOrder);
        }
    }
}
