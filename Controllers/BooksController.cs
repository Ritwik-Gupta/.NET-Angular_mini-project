using Microsoft.AspNetCore.Mvc;
using Summary_Application.Model;
using Summary_Application.Services;

namespace Summary_Application.Controllers
{
    [Route("api/[controller]")]
    public class BooksController:ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService service)
        {
            _bookService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpGet("GetBookById")]
        public IActionResult GetBookById(int id)
        {
            return Ok(_bookService.GetBookById(id));
        }

        [HttpPost("UpdateBook")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            _bookService.UpdateBook(id, book);
            return Ok("Book Updated");
        }

        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return Ok("Book Added");
        }

        [HttpGet("DeleteBook")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok("Book Deleted");
        }

        [HttpGet("GetNextAvailableId")]
        public IActionResult GetNextAvailableId()
        {
            return Ok(_bookService.GetNextAvailableId());
        }

        [HttpPost("AddMultipleBooks")]
        public IActionResult AddMultipleBooks([FromBody] List<Book> books)
        {
            _bookService.AddMultipleBooks(books);
            return Ok("Books Added!");
        }
    }
}
