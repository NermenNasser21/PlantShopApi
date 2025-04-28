using Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels.Account;

namespace PlantShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       
        private AccountManager accountManager;


        public AccountController(AccountManager _accountManager)
        {
            accountManager = _accountManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel _model)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "This Data Is Not Completed" });
            var res = await accountManager.Login(_model);
            if (res == string.Empty) return BadRequest(new { Message = "You do not have an account" });
            return Ok(new { token = res, exepire = DateTime.Now.AddDays(30), status = 200 });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel _model)
        {
            if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid Data " });
            var res = await accountManager.Register(_model);
            if(!res.Succeeded) return BadRequest(new {Message = "Error creating Account", Error = res.Errors.Select(e=>e.Description)});
            return Ok(res);


            
        }
    }
}
