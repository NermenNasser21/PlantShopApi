using Managers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ViewModels;

namespace PlantShopApi
{
    [Route("api/[controller]")]
    public class OrderController :ControllerBase
    {
        private OrderManager orderManager;
        private AccountManager accountManager;
        private CartManager cartManager;
        public OrderController(AccountManager _accountManager, CartManager _cartManager,OrderManager _orderManager )
        {
            accountManager = _accountManager;
            cartManager = _cartManager;
            orderManager = _orderManager;

        }
        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> AddOrder(AddOrderViewModel model)
        {
            if (!ModelState.IsValid) BadRequest(new{ Message ="the data is not valid"});
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (UserId == null) BadRequest(new { Message = "Can not find the current User" });
            model.UserId = UserId;
            var user = await accountManager.UserManager.FindByIdAsync(UserId);
 
            model.CartId = user.CartId;
            var res = await orderManager.Add(model);
            if (!res) BadRequest(new { Message = "there is not cart for this user" });
            return Ok();
        }

        [HttpGet("Getall")]
        public async Task<IActionResult> GetAll()
        {
            var Res =  orderManager.GetAll().ToList();

            return Ok(Res);
        }

        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOne(int _orderId)
        {
            var Res =await orderManager.GetOne(_orderId);

            return Ok(Res);
        }

    }
}
