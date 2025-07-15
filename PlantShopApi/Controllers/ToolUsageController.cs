
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
    public class ToolUsageController : ControllerBase
    {

        private ToolUsageManager ToolUsageManager;


        public ToolUsageController(ToolUsageManager _ToolUsageManager)
        {
            ToolUsageManager = _ToolUsageManager;
        }

        [HttpGet("GetAll")]
        public IQueryable<ToolUsage> GetAll()
        {
            var result =  ToolUsageManager.GetAll();
    
            return result;
        }
            
        
    }
}
