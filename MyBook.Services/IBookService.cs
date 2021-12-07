using FavoriteBook;
using System.Collections.Generic;



namespace MyBook.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(int page, int size);
        Book GetById(int id);
        Book SaveBook(Book item);
        Book SetStatus(int id, bool value, int pages, int published);
    }
}
