
using System.Security.Claims;
using Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels;

namespace PlantShopApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private CartManager cartManager;


        public CartController(CartManager _cartManager)
        {
            cartManager = _cartManager;
        }

        [HttpGet("GetOne")]
        public async Task<Cart> GetOne()
        {
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            var result = await cartManager.GetOne(UserId);
                
          
            return result;
        }
            
        
    }
}
