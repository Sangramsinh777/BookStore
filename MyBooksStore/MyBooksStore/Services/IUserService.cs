namespace MyBooksStore.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsLoggedUser();
    }
}