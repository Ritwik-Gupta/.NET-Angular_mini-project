using Summary_Application.Data.Model;

namespace Summary_Application.Data.Services
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBookById(int id);
        public void UpdateBook(int id, Book book);
        public void DeleteBook(int id);
        public void AddBook(Book book);

    }
}