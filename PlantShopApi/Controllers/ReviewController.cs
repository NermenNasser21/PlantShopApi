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


        [HttpGet("AllReviews")]
        public async Task<IActionResult> GetAllReviews()
        {

            var AllReviews = reviewMangaer.GetAll().ToList();
            if (AllReviews.Count == 0)
            {
                return BadRequest(new { Message = "There is no reviews yet. " });
            }
            return Ok(AllReviews);


        }

        [HttpGet("PlantReviews/{Id}")]
        public async Task<IActionResult> GetPlantReviews(int Id)
        {

            var PlantReviews = reviewMangaer.GetAll().Where(r => r.PlantId == Id).ToList();
            if(PlantReviews.Count==0)
            {
               return BadRequest(new { Message = "There is no reviews for that item. " });
            }
            return Ok(PlantReviews);


        }


        [HttpGet("ToolReviews/{Id}")]
        public async Task<IActionResult> GetToolReviews(int Id)
        {

            var ToolReviews = reviewMangaer.GetAll().Where(r => r.ToolId == Id).ToList();
            if (ToolReviews.Count == 0)
            {
                return BadRequest(new { Message = "There is no reviews for that item. " });
            }
            return Ok(ToolReviews);


        }

    }
}
