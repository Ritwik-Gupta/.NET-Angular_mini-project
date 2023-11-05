using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Summary_Application.Data;
using Summary_Application.Model;

namespace Summary_Application.Services
{
    public class BookService : IBookService
    {
        private readonly BooksDBContext _dbContext;
        public BookService(BooksDBContext context)
        {
            _dbContext = context;
        }
        public async Task AddBook(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            List<Book> result  = new List<Book>() { };
            try
            {
                result =  await _dbContext.Books.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task<Book> GetBookById(int id)
        {
            var result = await _dbContext.Books.FirstOrDefaultAsync(book => book.Id == id);
            if(result != null) { return result; }
            return new Book();
        }

        public async Task UpdateBook(int id, Book new_book)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(_book => _book.Id == id);
            if (book != null)
            {
                book.Author = new_book.Author;
                book.Title = new_book.Title;
                book.Description = new_book.Description;
                book.Rate = new_book.Rate;
                book.DateStart = new_book.DateStart;
                book.DateRead = new_book.DateRead;

                _dbContext.Books.Update(book);
            }
            await _dbContext.SaveChangesAsync();
        }

        public int GetNextAvailableId()
        {
            return _dbContext.Books.OrderByDescending(x => x.Id).First().Id + 1;
        }

        public async Task AddMultipleBooks(List<Book> books)
        {
            await _dbContext.Books.AddRangeAsync(books);
            await _dbContext.SaveChangesAsync();
        }
    }
}