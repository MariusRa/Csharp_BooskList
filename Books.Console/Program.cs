using Books.DataAccess;
using FavoriteBook;
using System;
using System.Collections.Generic;

namespace Books.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book();
            book1.Title = "The Orange Girl";
            book1.Author = "Jostein Gaarder";
            book1.Genre = "Romane";
            book1.Pages = 151;
            book1.Published = 2005;

            Book book2 = new Book();
            book2.Title = "Sophie's World";
            book2.Author = "Jostein Gaarder";
            book2.Genre = "Romane";
            book2.Pages = 403;
            book2.Published = 1995;

            Book book3 = new Book();
            book3.Title = "The Ringmaster's Daughter";
            book3.Author = "Jostein Gaarder";
            book3.Genre = "Romane";
            book3.Pages = 215;
            book3.Published = 2012;

            Book book4 = new Book();
            book4.Title = "Little Thieves";
            book4.Author = "Margaret Owen";
            book4.Genre = "Fiction";
            book4.Pages = 512;
            book4.Published = 2021;

            Book book5 = new Book();
            book5.Title = "Kingdom of the Cursed";
            book5.Author = "Kerri Maniscalco";
            book5.Genre = "Fantasy";
            book5.Pages = 448;
            book5.Published = 2021;
            
            Book book6 = new Book();
            book6.Title = "The City Beautiful";
            book6.Author = "Aden Polydoros";
            book6.Genre = "Horror";
            book6.Pages = 480;
            book6.Published = 2021;

            var bookList = new List<Book>
            {
                book1, book2, book3, book4, book5, book6
            };

            foreach (var book in bookList)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Add(book);
                    db.SaveChanges();
                }
            }
            
        }
    }
}
