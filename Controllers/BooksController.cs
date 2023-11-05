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
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookService.GetAllBooks());
        }

        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await _bookService.GetBookById(id));
        }

        [HttpPost("UpdateBook")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            await _bookService.UpdateBook(id, book);
            return Ok("Book Updated");
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            await _bookService.AddBook(book);
            return Ok("Book Added");
        }

        [HttpGet("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);
            return Ok("Book Deleted");
        }

        [HttpGet("GetNextAvailableId")]
        public IActionResult GetNextAvailableId()
        {
            return Ok(_bookService.GetNextAvailableId());
        }

        [HttpPost("AddMultipleBooks")]
        public async Task<IActionResult> AddMultipleBooks([FromBody] List<Book> books)
        {
            await _bookService.AddMultipleBooks(books);
            return Ok("Books Added!");
        }
    }
}
