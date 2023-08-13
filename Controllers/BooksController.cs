using Microsoft.AspNetCore.Mvc;
using Summary_Application.Data.Model;
using Summary_Application.Data.Services;

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

        [HttpPost("DeleteBook")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok("Book Deleted");
        }

    }
}
