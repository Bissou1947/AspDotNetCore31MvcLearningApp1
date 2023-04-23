namespace BookStoreWeb.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsUserAuthenticated();
    }
}