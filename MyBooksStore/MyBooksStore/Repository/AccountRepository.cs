using Microsoft.AspNetCore.Identity;
using MyBooksStore.Models;
using MyBooksStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        public AccountRepository(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager , IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUser)
        {
            var user = new ApplicationUser() { 
                FirstName=signUpUser.FirstName,
                LastName=signUpUser.LastName,
                Email=signUpUser.Email,
                UserName=signUpUser.Email
            };

            var result= await _userManager.CreateAsync(user, signUpUser.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePassword(ChangePasswordModel changePasswordModel)
        {
            var user =await _userManager.FindByIdAsync(_userService.GetUserId());
            return await _userManager.ChangePasswordAsync(user, changePasswordModel.CurrentPassword, changePasswordModel.NewPassword);
        }
    }
}
