using Managers;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace PlantShopApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantGrowthController : ControllerBase
    {
        private PlantGrowthMangaer plantGrowthMangaer;

        public PlantGrowthController(PlantGrowthMangaer _plantGrowthManager)
        {
            plantGrowthMangaer = _plantGrowthManager;
        
        }

        [HttpGet("Getall")]
        public async Task<IActionResult> GetAll() 
        {
            var Res =  plantGrowthMangaer.GetAll().ToList();

            return Ok(Res);
        }

        
    }
}
