using FavoriteBook;

namespace MyBook.Services
{
    public interface IUserService
    {
        User AddUser(User user);
        User CheckUser(string email);
    }
}