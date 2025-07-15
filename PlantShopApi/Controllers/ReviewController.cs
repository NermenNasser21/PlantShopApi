using Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Security.Claims;
using ViewModels;

namespace PlantShopApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private AccountManager accountMangaer;
        private ReviewManager reviewMangaer;
        private CartManager cartManager;
        

        public ReviewController(ReviewManager _reviewMangaer, CartManager _cartManager,AccountManager _accountManager)
        {
            reviewMangaer = _reviewMangaer;
            cartManager = _cartManager;
            accountMangaer = _accountManager;
        }

        [HttpPost("AddPlantReview")]
        public async Task<IActionResult> AddPlantReview(AddReviewViewModel model)
        {
           
                if (!ModelState.IsValid) BadRequest(new { Message = "This Data Is Not Completed" });
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userid == null) BadRequest(new { Message = "can not find the current user" });
                model.UserId = userid;
                
                var res = await reviewMangaer.Add(model.ToModel());
                if (!res) BadRequest(new { Message = "error occured while Adding review" });
                return Ok();

             
        }



        //[HttpGet("PlantReviews/{Id}")]
        //public Task<IActionResult> GetPlantReviews(int Id)
        //{
        //    var Plant = 



        //}


    }
}
