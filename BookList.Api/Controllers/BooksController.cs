using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FavoriteBook;
using MyBook.Services;
using BookList.Api.viewModels;

namespace BookList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService bookService)
        {
            _service = bookService;
        }

        //// GET: api/Books
        [HttpGet]
        public IEnumerable<Book> Get([FromQuery] int page = 1, int size = 5)
        {
            return _service.GetAllBooks(page,size);
        }

        //// GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _service.GetById(id);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookViewModel model)
        {
            Book newBook = new Book() { BookId = model.BookId, Title = model.Title, Author = model.Author, Genre = model.Genre, Pages = model.Pages, Published = model.Published };
            var result = _service.SaveBook(newBook);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookViewModelBool value)
        {
            return Ok(_service.SetStatus(id, value.IsRead, value.Pages, value.Published));
        }


    }
}
