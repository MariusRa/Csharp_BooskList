using Books.DataAccess;
using FavoriteBook;
using System.Linq;

namespace MyBook.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public User AddUser(User user)
        {
            var userCreated = _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }

        public User CheckUser(string email)
        {
            return _db.Users.FirstOrDefault(e => e.Email == email);
        }
    }
}
