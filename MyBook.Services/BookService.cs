using Books.DataAccess;
using FavoriteBook;
using System.Collections.Generic;
using System.Linq;



namespace MyBook.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _db;
        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Book> GetAllBooks(int page, int size)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Books.Skip((page -1) * size).Take(size).ToList();
            }
        }

        public Book GetById(int id)
        {
            return _db.Books.FirstOrDefault(x => x.BookId == id);
        }

        public Book SaveBook(Book item)
        {
            _db.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Book SetStatus(int id, bool value, int pages, int published)
        {
            var findBook = GetById(id);
            findBook.IsRead = value;
            findBook.Pages = pages;
            findBook.Published = published;

            _db.SaveChanges();

            return findBook;
        }
    }
}
