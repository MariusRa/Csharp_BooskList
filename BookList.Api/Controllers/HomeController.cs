using Microsoft.AspNetCore.Mvc;
using MyBook.Services;


namespace BookList.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _service;
        public HomeController(IBookService bookService)
        {
            _service = bookService;
        }
        public IActionResult Index()
        {
            var myBooks = _service.GetAllBooks(1, 10);
            return View(myBooks);
        }

        public IActionResult AboutBook()
        {
            return View();
        }

        public IActionResult IdBook(int id)
        {
            var myBookId = _service.GetById(id);
            return View(myBookId);
        }
    }
}
