
using System.Security.Claims;
using Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Models;
using ViewModels;

namespace PlantShopApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantUsageController : ControllerBase
    {

        private PlantUsageManager PlantUsageManager;


        public PlantUsageController(PlantUsageManager _PlantUsageManager)
        {
            PlantUsageManager = _PlantUsageManager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult>  GetAll()
        {
            var result =  PlantUsageManager.GetAll().ToList();
    
            return Ok(result);
        }
            
        
    }
}
