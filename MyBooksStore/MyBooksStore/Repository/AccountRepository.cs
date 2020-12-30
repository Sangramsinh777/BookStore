using Microsoft.AspNetCore.Identity;
using MyBooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
    }
}
