using Microsoft.EntityFrameworkCore;
using Summary_Application.Model;

namespace Summary_Application.Data
{
    public class BooksDBContext: DbContext
    {
        public BooksDBContext(DbContextOptions options): base(options) { }
        
        //These below are basically the tables in the DB
        public DbSet<Book> Books { get; set; }
    }
}
