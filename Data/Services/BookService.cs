using Summary_Application.Data.Model;

namespace Summary_Application.Data.Services
{
    public class BookService : IBookService
    {
        public void AddBook(Book book)
        {
            Data.Books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = Data.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                Data.Books.Remove(book);
            }
        }

        public List<Book> GetAllBooks()
        {
            return Data.Books;
        }

        public Book GetBookById(int id)
        {
            return Data.Books.FirstOrDefault(book => book.Id == id);
        }

        public void UpdateBook(int id, Book new_book)
        {
            var book = Data.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                book.Author = new_book.Author;
                book.Title = new_book.Title;
                book.Description = new_book.Description;
                book.Rate = new_book.Rate;
                book.DateStart = new_book.DateStart;
                book.DateRead = new_book.DateRead;
            }
        }
    }
}