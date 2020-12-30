using Microsoft.AspNetCore.Identity;
using MyBooksStore.Models;
using System.Threading.Tasks;

namespace MyBooksStore.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpUser);
    }
}