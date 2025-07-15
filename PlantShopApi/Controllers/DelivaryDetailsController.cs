
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
    public class DelivaryDetailsController : ControllerBase
    {

        private DelivaryDetailsManager DelivaryDetailsManager;


        public DelivaryDetailsController(DelivaryDetailsManager _DelivaryDetailsManager)
        {
            DelivaryDetailsManager = _DelivaryDetailsManager;
        }

      [HttpGet("GetAll")]
        public async Task<IActionResult>  GetAll()
        {
            var result =  DelivaryDetailsManager.GetAll().ToList();
    
            return Ok(result);
        }
            
        
      [HttpPost("AddDelivaryDetails")]
        public async Task<IActionResult>  AddDelivaryDetails(AddDelivaryDetailModeL model)
        {
            var result =  DelivaryDetailsManager.Add(model.ToModel());
    
            return Ok(result);
        }
    }
}
