using InfraStructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Account;

namespace Managers
{
    public class AccountManager : MainManager<User>
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private readonly TokenManager tokenManager;
        public AccountManager(PlantContext _context,UserManager<User> _userManager,SignInManager<User> _signInManager,TokenManager _tokenManager) : base(_context)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            tokenManager = _tokenManager;

        }
        public UserManager<User> UserManager => userManager;

        public async Task<IdentityResult> Register(RegisterViewModel model)
        {
            try
            {
                //var existingUser = await userManager.FindByEmailAsync(model.Email);
                //if (existingUser != null)
                //{
                //    return IdentityResult.Failed(new IdentityError { Description = "Email is already taken." });
                //}

                var user = model.ToModel();
                var createResult = await userManager.CreateAsync(user, model.Password);

                if (!createResult.Succeeded)
                {
                    return createResult; // Return the errors from creating the user
                }

                var roleResult = await userManager.AddToRoleAsync(user, "user");
                return roleResult;
            }
            catch (Exception ex)
            {
                // Ideally log the exception
                return IdentityResult.Failed(new IdentityError { Description = "An error occurred during registration." });
            }
        }


        public async Task<string> Login(LoginViewModel model)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                    return string.Empty;

                var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.IsLockedOut)
                {
                    return "LockedOut"; // Or handle it better
                }

                if (!result.Succeeded)
                {
                    return string.Empty;
                }

                return await tokenManager.GenerateToken(user);
            }
            catch (Exception ex)
            {
                // Ideally log the exception
                return string.Empty;
            }
        }


        public async void LogOut()
        {
           await signInManager.SignOutAsync();

        }
    }
}
