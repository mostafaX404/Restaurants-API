namespace Resturants.Application.User
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}