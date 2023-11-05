using Summary_Application.Model;

namespace Summary_Application.Services
{
    public interface IBookService
    {
        public Task<List<Book>> GetAllBooks();
        public Task<Book> GetBookById(int id);
        public Task UpdateBook(int id, Book book);
        public Task DeleteBook(int id);
        public Task AddBook(Book book);
        public Task AddMultipleBooks(List<Book> books);
        public int GetNextAvailableId();

    }
}