using Microsoft.AspNetCore.Identity;
using MyBooksStore.Models;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUser);
        Task<SignInResult> PasswordSignInAsync(SignInModel signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePassword(ChangePasswordModel changePasswordModel);
    }
}